class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    int speed;
    int batteryDrain;
      int meters;
     int battery=100;
    public RemoteControlCar(int speed,int batteryDrain){
        this.speed=speed;
        this.batteryDrain=batteryDrain;
    }

    public bool BatteryDrained()=>battery<batteryDrain;
    

    public int DistanceDriven()=>meters;
    

    public void Drive()
    {     if (BatteryDrained()){
            return;
        }
        meters+=speed;
        battery-=batteryDrain;
        
    }

    public static RemoteControlCar Nitro()=>new RemoteControlCar(50,4);
    
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class

    int distance;
    public RaceTrack(int distance){
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        
while(!car.BatteryDrained() && car.DistanceDriven()<distance){
    car.Drive();
}
        return car.DistanceDriven() >= distance;
}}
