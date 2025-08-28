public class GradeSchool
{
    private readonly IDictionary<string, int> _grade = new Dictionary<string, int>();
    private readonly SortedSet<string> _roster = new SortedSet<string>();


    public bool Add(string student, int grade)
    {
        if (_roster.Contains(student))
        {
            return false;
        }
        _roster.Add(student);
        _grade[student] = grade;
        return true;
    }

    public IEnumerable<string> Roster()
    {
        return _roster;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return _grade.Where(g => g.Value == grade).Select(g => g.Key);
    }
}