abstract class Character
    
{
    protected readonly string characterType;
    protected Character(string characterType)
    {
       this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {characterType}";
    
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
       if(target.Vulnerable()){
           return 10;
       }
        return 6;
    }
   
}

class Wizard : Character
{
    private static bool _preparedSpell = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(target.GetType()==typeof(Wizard)){
             if(target.Vulnerable()){
          return 12;
      }
        return 3;
     }else{
            if(_preparedSpell){
                return 12;
            }
            return 3;
        }
     
    }

    public void PrepareSpell() => _preparedSpell=true;
    

    public override bool Vulnerable(){
        if(_preparedSpell){
            return false;
        }
        return true;
    }
}
