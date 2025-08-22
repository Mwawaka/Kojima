public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch
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