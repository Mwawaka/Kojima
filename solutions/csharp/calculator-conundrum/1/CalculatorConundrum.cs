public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try{
        if(operation == "+" || operation == "*" || operation == "/"){
             int result = 0;
           switch (operation){
               case "+":
                   result= Addition(operand1, operand2);
                   break;
               case "*":
                   result= Multiplication(operand1, operand2);
                   break;
               case "/":
                   result= Division(operand1, operand2);
                   break;       
       }
           return $"{operand1} {operation} {operand2} = {result}";
    }else if (operation == ""){
            throw new ArgumentException("Empty string");
    }else if (operation == null){
            throw new ArgumentNullException("Null value");
    }else{
            throw new ArgumentOutOfRangeException("Out of range value");
    }
        }catch(DivideByZeroException){
            return "Division by zero is not allowed.";
        }
    }
       

    private static int Addition(int operand1,int operand2) => operand1 + operand2;
    private static int Multiplication(int operand1,int operand2) => operand1 * operand2;
    private static int Division(int operand1,int operand2){ 
        if(operand2==0){
            throw new DivideByZeroException("Division by zero is not allowed.");
        }    
        return operand1 / operand2;
    }
}
