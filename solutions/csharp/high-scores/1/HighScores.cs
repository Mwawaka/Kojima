public class HighScores
{
    public List<int> ListScores;
    public HighScores(List<int> list)
    {
        ListScores = list;
    }

    public List<int> Scores() => ListScores;
    public int Latest() => ListScores[ListScores.Count - 1];
    public int PersonalBest() => SortList(ListScores)[0];

    public List<int> PersonalTopThree()
    {
        List<int> sortedList = SortList(ListScores);
        List<int> personalTopThree = new List<int> ();
        
        if (sortedList.Count > 0) personalTopThree.Add(sortedList[0]);
        if (sortedList.Count > 1) personalTopThree.Add(sortedList[1]);
        if (sortedList.Count > 2) personalTopThree.Add(sortedList[2]);
        return personalTopThree;
        // USING LINQ sortedList.Take(3).ToList();
    }

    public List<int> SortList(List<int> list)
    {
        List<int> newList = new List<int>(list);
        newList.Sort((a, b) => b.CompareTo(a));
        return newList;
    }
}