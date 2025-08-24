using System.Text;

namespace DecimalTests.Base;

public abstract class BaseTest
{
    public BaseTest(string fileName, string path)
    {
        FileName = fileName;
        Path = path;
    }

    internal virtual CheckSuiteModel AddSuite(string suiteName)
    {
        var newSuite = new CheckSuiteModel(suiteName);
        Suites.Add(newSuite);
        return newSuite;
    }

    public StringBuilder Sb { get; set; } = new StringBuilder();
    private string FileName { get; set; }
    private string Path { get; set; }
    internal List<CheckSuiteModel> Suites { get; private set; } = new List<CheckSuiteModel>();

    internal virtual string GetHeader()
    {
        var sb = new StringBuilder();
        sb.AppendLine("#include \"../binary/s21_big_binary.h\"");
        sb.AppendLine("#include <check.h>");
        return sb.ToString();
    }

    internal void Export()
    {
        using (StreamWriter sw = new StreamWriter($"{Path}\\{FileName}.c"))
        {
            sw.WriteLine(GetHeader());
            foreach (var suit in Suites)
            {
                suit.ExportSuit(s =>
                {
                    sw.WriteLine(s);
                });
            }

            sw.WriteLine("int main(void) {");
            sw.WriteLine("    Suite *s;");
            sw.WriteLine("    SRunner *sr;");
            sw.WriteLine("    int failures;");

            foreach (var suit in Suites)
            {
                sw.WriteLine($"    *s = {suit.Name}();");
                sw.WriteLine("    *sr = srunner_create(s);");
                sw.WriteLine("    srunner_run_all(sr, CK_NORMAL);");
                sw.WriteLine("    failures += srunner_ntests_failed(sr);");
            }
            
            sw.WriteLine("    srunner_free(sr);");
            sw.WriteLine("    return (failures == 0) ? 0 : 1;");
            sw.WriteLine("}");
        }        
        
        System.Console.WriteLine("Text written to file successfully.");
    }
}