public class Program
{
    public static string KebabToCamel(string identifier)
    {
        int[] pos = new int[identifier.Length];
        for (int i = 0; i < identifier.Length; i++)
        {
            int characterPosition = identifier.IndexOf("-");
            pos[i] = characterPosition;
        }
        for (int i = 0; i < pos.Length; i++)
        {
            
        }
    }
    public static void Main(string[] args)
    {
        KebabToCamel("a-bc");

    }
}
