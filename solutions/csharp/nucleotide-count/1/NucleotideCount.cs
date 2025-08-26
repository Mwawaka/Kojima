public static class NucleotideCount
{
    private static readonly HashSet<char> _nucleotides = new HashSet<char> { 'A', 'C', 'G', 'T' };
    public static IDictionary<char, int> Count(string sequence)
    {
        IDictionary<char, int> nucleotideCount = new Dictionary<char, int>{
            {'A',0},
            {'C',0},
            {'G',0},
            {'T',0}
        };

        if (string.IsNullOrEmpty(sequence)) return nucleotideCount;
        if (!IsDnaStrand(sequence))
        {
            throw new ArgumentException("not a valid nucleotide sequence");
        }

        foreach (char c in sequence)
        {
            nucleotideCount[c]++;
        }
        return nucleotideCount;
    }
    public static bool IsDnaStrand(string sequence) => sequence.All(c => _nucleotides.Contains(c));

}