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
}
public class Weapon : Equipment
{
    public WeaponType Type = WeaponType.Sword;
    public int MinDamage = 1;
    public int MaxDamage = 4;
    public float attackTime = .6f;
}

public class Armor : Equipment
{
    public int Defense = 1;
    public ArmorType Type = ArmorType.Helmet;

}
public class SimpleRotation : MonoBehaviour
{
    [Header("Rotato")]
    public Vector3 RotationPerSecond;
    void Update()
    {
        transform.Rotate(RotationPerSecond * Time.deltaTime, 2.3f);

    }
}