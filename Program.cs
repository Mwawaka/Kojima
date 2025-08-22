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
        if (sortedList.Count == 1)
        {
            return sortedList;
        }
        else if (sortedList.Count == 2)
        {
            return new List<int>{
                sortedList[0],
                sortedList[1]
            };
        }
        else
        {
            return new List<int>{
                sortedList[0],
                sortedList[1],
                sortedList[2]
            };
        }
    }

    public List<int> SortList(List<int> list)
    {
        List<int> newList = [.. list];
        if (list.Count == 1)
        {
            return newList;
        }
        newList.Sort((a, b) => b.CompareTo(a));
        return newList;
    }
}