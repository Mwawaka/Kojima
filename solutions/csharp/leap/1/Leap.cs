public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        if (year % 100 == 0){
             return (year / 100) % 4 == 0 ? true : false;
        }else if(year % 4 == 0){
            return true;
        }
        return false;
    }
}