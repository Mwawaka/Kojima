using UnityEngine;

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
    public int CurrentDurability;
    public int MaximumDurability;
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