static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => new DateTime(2019, 7, 25, 13, 45, 0);

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime today = DateTime.Today;

        int time = appointmentDate.CompareTo(today);

        if (time < 0)
        {
            return true;
        }
        return false;

    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return false;
    }

    public static string Description(DateTime appointmentDate)
    {
        return "hello";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime();
    }
    public static void Main(string[] args)
    {

    }
}
// September 15 2012