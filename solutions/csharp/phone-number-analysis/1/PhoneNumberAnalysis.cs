public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    { 
        var (sec1, sec2, sec3) = SplitString(phoneNumber);
        return (sec1 == "212", sec2 == "555", sec3);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
    
    public static (string,string,string) SplitString(string phoneNumber){
        string sec1 = phoneNumber.Split('-')[0];
        string sec2 = phoneNumber.Split('-')[1];
        string sec3 = phoneNumber.Split('-')[2];

        return (sec1, sec2, sec3);
    }
}
