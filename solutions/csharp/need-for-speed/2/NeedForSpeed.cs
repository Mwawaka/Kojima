class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    private readonly int _speed;
    private readonly int _batteryDrain;
    private int _meters;
    private int _battery=100;
    
    public RemoteControlCar(int _speed,int _batteryDrain){
        this._speed = _speed;
        this._batteryDrain = _batteryDrain;
    }

    public bool BatteryDrained() => _battery < _batteryDrain;
    

    public int DistanceDriven()=>  _meters;
    

    public void Drive()
    {     if (BatteryDrained()){
            return;
        }
        _meters += _speed;
        _battery -= _batteryDrain;
        
    }

    public static RemoteControlCar Nitro()=>new RemoteControlCar(50,4);
    
}

class RaceTrack
{
    private readonly int _distance;
    
    public RaceTrack(int _distance){
        this._distance = _distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        
while(!car.BatteryDrained() && car.DistanceDriven() < _distance){
    car.Drive();
}
        return car.DistanceDriven() >= _distance;
}}
