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

    public bool IsClaimStaked(Plot plot)
    {

        return Claims.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {

        return plot.Equals(_lastClaim);

    }

    public Plot GetClaimWithLongestSide()
    {
        return new Plot();

    }
}