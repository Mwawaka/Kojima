using UnityEngine;
public enum ArmorType
{
    Helmet,
    Chest,
    Gloves,
    Belt,
    Boots
}
public enum WeaponType
{
    Axe,
    Sword,
    Hammer,
    Knife,
}
public class Item
{
    public int Worth;
    public string Name;
    public bool CanBeSold;

    public Item(int worth, string name, bool canBeSold)
    {
        Worth = worth;
        Name = name;
        CanBeSold = canBeSold;
    }
}
public class Equipment : Item
{
    public int CurrentDurability = 100;
    public int MaximumDurability = 100;

    public Equipment(int worth, string name, bool canBeSold, int maximumDurability) : base(worth, name, canBeSold)
    {
        MaximumDurability = maximumDurability;
        CurrentDurability = MaximumDurability;
    }
}
public class Weapon : Equipment
{
    public WeaponType Type = WeaponType.Sword;
    public int MinDamage = 1;
    public int MaxDamage = 4;
    public float AttackTime = .6f;

    public Weapon(int worth, string name, bool canBeSold, int maximumDurability, WeaponType type, int minDamage, int maxDamage, float attackTime) : base(worth, name, canBeSold, maximumDurability)
    {
        Type = type;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        AttackTime = attackTime;
    }
}

public class Armor : Equipment
{
    public ArmorType Type = ArmorType.Helmet;
    public int Defense = 1;
    public Armor(int worth, string name, bool canBeSold, int maximumDurability, ArmorType type, int defense) : base(worth, name, canBeSold, maximumDurability)
    {
        Type = type;
        Defense = defense;
    }
}

public class SimpleRotation : MonoBehaviour
{
    [Header("Rotato")]
    public Vector3 RotationPerSecond;

    void Start()
    {
        Item item = new Weapon(90, "Rusty Axe", false, 100, WeaponType.Axe, 3, 11, .3f);

        Weapon weapon = (Weapon)item;

        Debug.Log($"The {weapon.Name} costs {weapon.Worth} gold coints. It has {weapon.MaximumDurability}maximum durability.");
    }
    void Update()
    {
        transform.Rotate(RotationPerSecond * Time.deltaTime, 2.3f);

    }
}