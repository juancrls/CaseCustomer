using Domain;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Common.Extensions;

public static class StringExtensions
{
    public static bool IsCpf(this string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");
        cpf = cpf.PadLeft(11, '0');

        var reg = new Regex(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)");

        if (!reg.IsMatch(cpf))
            return false;

        int d1;
        int d2;
        var sum = 0;

        var weight1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var weight2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var n = new int[11];

        if (cpf.Length != 11)
            return false;

        switch (cpf)
        {
            case "00000000000":
                return false;

            case "11111111111":
                return false;

            case "2222222222":
                return false;

            case "33333333333":
                return false;

            case "44444444444":
                return false;

            case "55555555555":
                return false;

            case "66666666666":
                return false;

            case "77777777777":
                return false;

            case "88888888888":
                return false;

            case "99999999999":
                return false;
        }

        try
        {
            n[0] = Convert.ToInt32(cpf.Substring(0, 1));
            n[1] = Convert.ToInt32(cpf.Substring(1, 1));
            n[2] = Convert.ToInt32(cpf.Substring(2, 1));
            n[3] = Convert.ToInt32(cpf.Substring(3, 1));
            n[4] = Convert.ToInt32(cpf.Substring(4, 1));
            n[5] = Convert.ToInt32(cpf.Substring(5, 1));
            n[6] = Convert.ToInt32(cpf.Substring(6, 1));
            n[7] = Convert.ToInt32(cpf.Substring(7, 1));
            n[8] = Convert.ToInt32(cpf.Substring(8, 1));
            n[9] = Convert.ToInt32(cpf.Substring(9, 1));
            n[10] = Convert.ToInt32(cpf.Substring(10, 1));
        }
        catch
        {
            return false;
        }

        for (var i = 0; i <= weight1.GetUpperBound(0); i++)
            sum += (weight1[i] * Convert.ToInt32(n[i]));

        var resto = sum % 11;

        if (resto is 1 or 0)
            d1 = 0;
        else
            d1 = 11 - resto;

        sum = 0;

        for (var i = 0; i <= weight2.GetUpperBound(0); i++)
            sum += (weight2[i] * Convert.ToInt32(n[i]));

        resto = sum % 11;

        if (resto == 1 || resto == 0)
            d2 = 0;
        else
            d2 = 11 - resto;

        var calculado = d1 + d2.ToString(CultureInfo.InvariantCulture);
        var digitado = n[9] + n[10].ToString(CultureInfo.InvariantCulture);

        return calculado == digitado;
    }

    public static bool IsDate(this string s) => DateTime.TryParseExact(s, new[] { "dd/MM/yyyy", "MM/dd/yyyy", "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss" },
        CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

    public static string OnlyNumbers(this string s) => new(s.Where(char.IsDigit).ToArray());

    public static string Format(this string source, FormatType formatType)
    {
        if (string.IsNullOrWhiteSpace(source)) return string.Empty;

        var format = "";
        var text = source.OnlyNumbers();

        if (string.IsNullOrWhiteSpace(text)) return string.Empty;

        format = formatType switch
        {
            FormatType.Cpf => @"{0:000\.000\.000\-00}",
            _ => format
        };

        return !string.IsNullOrWhiteSpace(format)
            ? string.Format(format, Convert.ToDouble(text))
            : source;
    }
}