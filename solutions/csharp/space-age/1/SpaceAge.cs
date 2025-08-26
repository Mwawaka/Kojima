public class SpaceAge
{
    private readonly double _days;
    private const double _earthYears = 365.25;
    
    public SpaceAge(int seconds)
    {
        _days = GetDays(seconds);
    }

    public double OnEarth() => (_days / _earthYears) / 1.0;

    public double OnMercury() => (_days / _earthYears) / 0.2408467;
    
    public double OnVenus() => (_days / _earthYears) / 0.61519726;
    
    public double OnMars() => (_days / _earthYears) / 1.8808158;
    
    public double OnJupiter() => (_days / _earthYears) / 11.862615;
    
    public double OnSaturn() => (_days / _earthYears) / 29.447498;
    
    public double OnUranus() => (_days / _earthYears) / 84.016846;
    
    public double OnNeptune() => (_days / _earthYears) / 164.79132;
    
    public double GetDays(int seconds) => seconds / 86400.0;
}