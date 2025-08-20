public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; } = "";
    private Speed currentSpeed;
    public TelemetrySys Telemetry { get; }

    public RemoteControlCar()
    {
        Telemetry = new TelemetrySys(this);
    }

    public class TelemetrySys
    {
        private readonly RemoteControlCar _car;
        public TelemetrySys(RemoteControlCar car) => _car = car;
        public void Calibrate() { }
        public bool SelfTest() => true;
        public void ShowSponsor(string sponsorName) => _car.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString) =>
           _car.SetSpeed(new Speed(amount, unitsString == "cps" ? SpeedUnits.CentimetersPerSecond : SpeedUnits.MetersPerSecond));

    }
    struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {

            string unitsString = SpeedUnits == SpeedUnits.CentimetersPerSecond ? "centimeters per second" : "meters per second";
            return $"{Amount} {unitsString}";
        }
    }
    enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }
    public string GetSpeed() => currentSpeed.ToString();
    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;
    private void SetSpeed(Speed speed) => currentSpeed = speed;
    public static void Main(string[] args)
    {
        var car = new RemoteControlCar();
        car.Telemetry.Calibrate();
        car.Telemetry.SelfTest();
        car.Telemetry.ShowSponsor("Walker Industries Inc.");
        Console.WriteLine(car.CurrentSponsor);
        car.Telemetry.SetSpeed(100, "cps");
        car.GetSpeed();
    }
}