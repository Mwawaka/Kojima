public enum Color
{
    black,
    brown,
    red,
    orange,
    yellow,
    green,
    blue,
    violet,
    grey,
    white
}

public static class ResistorColor
{
    public static int ColorCode(string color) => color switch
    {
        "black" => 0,
        "brown" => 1,
        "red" => 2,
        "orange" => 3,
        "yellow" => 4,
        "green" => 5,
        "blue" => 6,
        "violet" => 7,
        "grey" => 8,
        "white" => 9,
        _ => 0,

    };


    public static string[] Colors() => [ "black", "brown","red","orange", "yellow", "green","blue", "violet", "grey", "white"
    ];

}