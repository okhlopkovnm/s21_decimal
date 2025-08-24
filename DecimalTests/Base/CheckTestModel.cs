using System.Text;

namespace DecimalTests.Base;

public class CheckTestModel
{
    internal CheckTestModel(string name)
    {
        Name = name;
    }

    internal void ExportTest(Action<string> writeLine)
    {
        writeLine("START_TEST(" + Name + ") {");
        writeLine(Sb.ToString());
        writeLine("}");
        writeLine("END_TEST");
        writeLine("");
    }

    internal void ExportTest2(string caseName, Action<string> writeLine)
    {
        writeLine($"  tcase_add_test({caseName}, {Name});");
    }

    private string Name { get; set; }
    internal StringBuilder Sb { get; set; }
}