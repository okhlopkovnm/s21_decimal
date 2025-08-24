namespace DecimalTests.Base;

public class CheckSuiteModel
{
    internal CheckSuiteModel(string name)
    {
        Name = name;
    }

    internal CheckCaseModel AddCase(string name)
    {
        var cas = new CheckCaseModel(name);
        Cases.Add(cas);
        return cas;
    }

    internal void ExportSuit(Action<string> writeLine)
    {
        foreach (var cas in Cases)
        {
            cas.ExportTests(writeLine);
        }
        writeLine($"Suite *{Name}(void) {{");
        writeLine($"  Suite *{Name}Suit = suite_create(\"{Name}\");");
        foreach (var cas in Cases)
        {
            cas.ExportCase($"{Name}Suit", writeLine);
        }
        writeLine($"  return {Name}Suit;");
        writeLine("}");
        writeLine("");
    }

    internal string Name { get; private set; }
    private List<CheckCaseModel> Cases { get; set; } = new List<CheckCaseModel>();
}