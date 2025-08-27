using System.Text;
using DecimalTests.Base;

namespace DecimalTests.Templates;

public class BinarySubTests : BaseTest
{
    public BinarySubTests(string fileName, string path) : base(fileName, path)
    {
    }

    private void Test(CheckCaseModel cas, string testName, decimal num1, decimal num2)
    {
        var test1 = cas.AddTest(testName);

        test1.Sb.AppendLine(Helpers.BigVariable("num1", num1));
        test1.Sb.AppendLine(Helpers.BigVariable("num2", num2));
        test1.Sb.AppendLine(Helpers.BigVariable("original", num1 - num2));
        test1.Sb.AppendLine("    s21_big_decimal result = s21_big_binary_sub(num1, num2);");
        test1.Sb.AppendLine(Helpers.AssertBig());
    }
    
    internal override string GetHeader()
    {
        var sb = new StringBuilder();
        sb.AppendLine("#include \"../lib/s21_sub.c\"");
        sb.AppendLine("#include <check.h>");
        return sb.ToString();
    }
    

    public void Exec()
    {
        var suite1 = AddSuite("sub");
        var case1 = suite1.AddCase("core");
        Test(case1, "sub_simple", new decimal([321, 0, 0, 0]), new decimal([100, 0, 0, 0]));
        Test(case1, "sub_nil_should_be_same", new decimal([123123, 12, 4, 0]), new decimal([0, 0, 0, 0]));
        Test(case1, "sub_same_should_be_nil", new decimal([321, 0, 0, 0]), new decimal([321, 0, 0, 0]));
        Test(case1, "sub_1", 654846548.5464654m, 546987984.5464654m);
        Export();
    }
}