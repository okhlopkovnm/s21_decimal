using System.Text;

namespace DecimalTests.Base;

public class CheckCaseModel
{
    internal CheckCaseModel(string name)
    {
        Name = name;
    }

    internal CheckTestModel AddTest(string name)
    {
        var test = new CheckTestModel(name)
        {
            Sb = new StringBuilder()
        };
        Tests.Add(test);
        return test;
    }

    internal void ExportTests(Action<string> writeLine)
    {
        foreach (var test in Tests)
        {
            test.ExportTest(writeLine);
        }
    }

    internal void ExportCase(string suiteName, Action<string> writeLine)
    {
        writeLine($"  TCase *{Name}Case = tcase_create(\"{Name}\");");
        foreach (var test in Tests)
        {
            test.ExportTest2($"{Name}Case", writeLine);
        }

        writeLine($"  suite_add_tcase({suiteName}, {Name}Case);");
    }

    internal string Name { get; private set; }
    private List<CheckTestModel> Tests { get; set; } = new List<CheckTestModel>();
}