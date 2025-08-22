public class Player
{
    private readonly Random _rand = new Random();
    public int RollDie() => _rand.Next(1,18);

    public double GenerateSpellStrength() => _rand.NextDouble() * 100.0; // 0.0 - 0.99
}