public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed;
    public TelemetrySys Telemetry { get; }

    public RemoteControlCar()
    {
        Telemetry = new TelemetrySys(this);
    }

     public class TelemetrySys
    {
        private readonly RemoteControlCar _car;
        public TelemetrySys(RemoteControlCar car)
        {
            _car = car;
        }
        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
           _car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

           _car.SetSpeed(new Speed(amount, speedUnits));
        }
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
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
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
}