public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int hammingDistance = 0;
        char[] first = firstStrand.ToCharArray();
        char[] second = secondStrand.ToCharArray();
        Console.WriteLine($"first {first}");
        for (int i = 0; i < firstStrand.Length; i++)
        {
            if (first[i] != second[i])
            {
                hammingDistance++;
            }
        }
        return hammingDistance;
    }
}

int ham = Hamming.Distance("GAGCCTACTAACGGGAT", "CATCGTAATGACGGCCT");
Console.WriteLine("Hamming Distance: {0}", ham);

// dotnet script *.csx -to run scripts