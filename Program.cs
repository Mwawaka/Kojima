public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int hammingDistance = 0;
        char[] first = firstStrand.ToCharArray();
        char[] second = secondStrand.ToCharArray();

        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (first[i] != second[i])
            {
                hammingDistance++;
            }
        }
        return hammingDistance;
    }
    public static void Main(string[] args)
    {
        int ham = Distance("GAGCCTACTAACGGGAT", "CATCGTAATGACGGCCT");
        Console.WriteLine("Hamming Distance: {0}", ham);
    }
}