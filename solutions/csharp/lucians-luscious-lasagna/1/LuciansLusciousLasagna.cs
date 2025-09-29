class Lasagna
{
    
    public  int ExpectedMinutesInOven () => 40;

   public  int RemainingMinutesInOven(int time) => 40 - time ; 

    public  int PreparationTimeInMinutes(int layers) => layers * 2;

    public  int ElapsedTimeInMinutes(int layers, int time) => layers * 2 + time ;
}
