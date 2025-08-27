public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int hammingDistance = 0;
        char [] first = firstStrand.ToCharArray();
        char [] second = secondStrand.ToCharArray();

        if(firstStrand.Length != secondStrand.Length){
            throw new ArgumentException("strands must be of equal length");
        }
        for(int i = 0; i < firstStrand.Length; i++){
            if(first[i] != second[i]){
                hammingDistance++;
            }
        }
        return hammingDistance;
    }
}