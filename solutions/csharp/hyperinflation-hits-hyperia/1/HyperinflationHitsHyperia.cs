public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try{
        long denomination = checked(@base * multiplier);
        return $"{denomination}";
            
        }catch(Exception ex){
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
    
        float denomination = checked(@base * multiplier);
        return float.IsInfinity(denomination) ? "*** Too Big ***" : $"{denomination}";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try{
        decimal denomination = checked(salaryBase * multiplier);
        return $"{denomination}";
            
        }catch(Exception ex){
            return "*** Much Too Big ***";
        }
    }
}
