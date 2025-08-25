namespace WeighingMachine
{
    class WeighingMachine
    {
        public int Precision { get; }
        private double _weight;
        public double Weight
        {
            get => _weight;
            set => _weight = value < 0 ? throw new ArgumentOutOfRangeException() : value;
        }
        public double TareAdjustment { get; set; } = 5.0d;
        private string _displayWeight;
        public string DisplayWeight
        {
            get
            {
                double displayWeight = Math.Round((Weight - TareAdjustment), Precision);
                return displayWeight.ToString($"N{Precision}") + " " + "kg";
            }
        }

        public WeighingMachine(int precision)
        {
            Precision = precision;
        }

    }
}