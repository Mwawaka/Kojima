public class Robot
{   private static readonly Random _rand = new Random();
 private static readonly HashSet<string> _usedNames = new HashSet<string>();
    private string _name;
    public string Name
    {
        get
        {
            _name = string.IsNullOrEmpty(_name) ? GenerateRandomName() : _name;
            return _name;
        }
        set{
            _name = value;
        }
    }

    public void Reset()
    {
      _name = GenerateRandomName();
    }
 public static string GenerateRandomName(){
     string name;
     do{
         int randomNumber = _rand.Next(100,1000); 
          int randomLetter1 = _rand.Next(0,26);
          int randomLetter2 = _rand.Next(0,26);
          char letter1 = Convert.ToChar(randomLetter1 + 65);
          char letter2 = Convert.ToChar(randomLetter2 + 65);
          name = $"{letter1}{letter2}{randomNumber}";
     }while(!_usedNames.Add(name));
     
     return name;     
 }
}