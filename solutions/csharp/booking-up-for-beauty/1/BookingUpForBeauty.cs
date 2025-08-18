static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate)
    {
        int time = appointmentDate.CompareTo(DateTime.Now);
        return (time < 0) ?  true : false;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
       int hour = appointmentDate.Hour;

       return (hour >= 12 && hour < 18) ? true : false;
    }

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate}.";

    public static DateTime AnniversaryDate() => new DateTime((DateTime.Now).Year, 9, 15, 0, 0, 0);
}
