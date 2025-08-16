using System.Text;

public class Program
{
    public static string KebabToCamel(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        bool capitalizeNext = false;
        foreach (char ch in identifier)
        {
            if (ch == '-')
            {
                capitalizeNext = true;
            }
            else
            {
                if (capitalizeNext)
                {
                    sb.Append(Char.ToUpper(ch));
                    capitalizeNext = false;
                }
                else
                {
                    sb.Append(ch);
                }
            }
        }
        return sb.ToString();
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(KebabToCamel("a-bc"));

    }
}
