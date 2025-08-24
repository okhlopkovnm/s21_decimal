using System.Text;
using DecimalTests.Base;

namespace DecimalTests.Templates;

public class BinaryAddTests : BaseTest
{
    public BinaryAddTests(string fileName, string path) : base(fileName, path)
    {
    }

    private void BirnaryAddTest(CheckCaseModel cas, string testName, decimal num1, decimal num2)
    {
        var test1 = cas.AddTest(testName);

        test1.Sb.AppendLine(Helpers.BigVariable("num1", num1));
        test1.Sb.AppendLine(Helpers.BigVariable("num2", num2));
        test1.Sb.AppendLine(Helpers.BigVariable("original", num1 + num2));
        test1.Sb.AppendLine("    s21_big_decimal result = s21_big_binary_add(num1, num2);");
        test1.Sb.AppendLine(Helpers.AssertBig());
    }
    
    internal override string GetHeader()
    {
        var sb = new StringBuilder();
        sb.AppendLine("#include \"../../lib/binary/s21_big_binary.h\"");
        sb.AppendLine("#include \"../../lib/binary/s21_big_binary_add.c\"");
        sb.AppendLine("#include <check.h>");
        return sb.ToString();
    }
    

    public void Exec()
    {
        var suite1 = AddSuite("add_suite_1");
        var case1 = suite1.AddCase("case1_1");
        BirnaryAddTest(case1, "add1_1_1", new decimal([123123, 12, 4, 0]), new decimal([54654, 44, 9878, 0]));
        BirnaryAddTest(case1, "add1_1_2", new decimal([321, 0, 4, 0]), new decimal([987978987, 44, 0, 0]));
        var case2 = suite1.AddCase("case1_2");
        BirnaryAddTest(case2, "add1_2_1", new decimal([123123, 12, 4, 0]), new decimal([54654, 44, 9878, 0]));
        BirnaryAddTest(case2, "add1_2_2", new decimal([321, 0, 4, 0]), new decimal([987978987, 44, 0, 0]));

        var suite2 = AddSuite("add_suite_2");
        var case21 = suite2.AddCase("case2_1");
        BirnaryAddTest(case21, "add2_1_1", new decimal([123123, 12, 4, 0]), new decimal([54654, 44, 9878, 0]));
        BirnaryAddTest(case21, "add2_1_2", new decimal([321, 0, 4, 0]), new decimal([987978987, 44, 0, 0]));
        var case22 = suite2.AddCase("case2_2");
        BirnaryAddTest(case22, "add2_2_1", new decimal([123123, 12, 4, 0]), new decimal([54654, 44, 9878, 0]));
        BirnaryAddTest(case22, "add2_2_2", new decimal([321, 0, 4, 0]), new decimal([987978987, 44, 0, 0]));
        Export();
    }
}