public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord Coord1;
    public Coord Coord2;
    public Coord Coord3;
    public Coord Coord4;

    public Plot(Coord cord1, Coord cord2, Coord cord3, Coord cord4)
    {
        Coord1 = cord1;
        Coord2 = cord2;
        Coord3 = cord3;
        Coord4 = cord4;
    }
}


public class ClaimsHandler
{
    private readonly HashSet<Plot> Claims = new HashSet<Plot>();
    private Plot _lastClaim;

    public void StakeClaim(Plot plot)
    {
        Claims.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot) => Claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => plot.Equals(_lastClaim);

    public Plot GetClaimWithLongestSide()
    {
        Plot longestPlot = Claims.First();
        double maxLength = 0;

        foreach (Plot plot in Claims)
        {
            double width = Math.Sqrt(Math.Pow(plot.Coord2.X - plot.Coord1.X, 2) + Math.Pow(plot.Coord2.Y - plot.Coord1.Y, 2));

            double height = Math.Sqrt(Math.Pow(plot.Coord3.X - plot.Coord1.X, 2) + Math.Pow(plot.Coord3.Y - plot.Coord1.Y, 2));

            double currentMax = Math.Max(width, height);

            if (currentMax > maxLength)
            {
                maxLength = currentMax;
                longestPlot = plot;
            }
        }
        return longestPlot;

    }
}
// Distance between 2 coordinates: `√((x₂-x₁)² + (y₂-y₁)²)`