using System.Text;

namespace DecimalTests.Base;

public static class Helpers
{
    internal static string DecimalVariable(string varName, decimal value)
    {
        var bits = decimal.GetBits(value);
        return $"    s21_decimal {varName} = {{{{{bits[0]}, {bits[1]}, {bits[2]}, {bits[3]}}}}};";
    }
    
    internal static string BigVariable(string varName, decimal value)
    {
        var bits = decimal.GetBits(value);
        return $"    s21_big_decimal {varName} = {{{{{bits[0]}, {bits[1]}, {bits[2]}, {bits[3]}, 0, 0, 0}}}};";
    }

    internal static string AssertBig(string name1 = "original", string name2 = "result")
    {
        var sb = new StringBuilder();
        for (int i = 0; i < 7; ++i)
        {
            sb.AppendLine($"    ck_assert_int_eq({name1}.bits[{i}], {name2}.bits[{i}]);");
        }

        return sb.ToString();
    }
}