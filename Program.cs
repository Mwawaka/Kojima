public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 =>
                "right back",
            >= 6 and <= 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => "UNKNOWN",
        };
    }

    public static string AnalyzeOffField(object report) => report switch
    {
        int => $"There are {report} supporters at the match.",
        string => $"{report}",
        Foul => "The referee deemed a foul.",

        // case  Injury {player: var player}
        Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
        Incident => "An incident happened.",
        Manager manager when manager.Club != null => $"{manager.Name} ({manager.Club})",
        Manager manager => $"{manager.Name}",
        _ => ""

    };

}

public class Manager
{
    public string Name { get; }

    public string? Club { get; }

    public Manager(string name, string? club)
    {
        this.Name = name;
        this.Club = club;
    }
}

public class Incident
{
    public virtual string GetDescription() => "An incident happened.";
}

public class Foul : Incident
{
    public override string GetDescription() => "The referee deemed a foul.";
}

public class Injury : Incident
{
    private readonly int player;

    public Injury(int player)
    {
        this.player = player;
    }

    public override string GetDescription() => $"Player {player} is injured.";
}