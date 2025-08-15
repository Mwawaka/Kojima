class RemoteControlCar
{
    public int Meters = 0;
    public int BatteryPercentage = 100;
    public static RemoteControlCar Buy()=> new RemoteControlCar();
    

    public string DistanceDisplay()=>$"Driven {Meters} meters";
    

    public string BatteryDisplay()
    {
        if(BatteryPercentage==0){
            return "Battery empty";
        }
        return $"Battery at {BatteryPercentage}%";
    }
    

    public void Drive()
    {
        if (BatteryPercentage == 0){
            return;
        }
       Meters=Meters+20;
       BatteryPercentage--;
    }
}
