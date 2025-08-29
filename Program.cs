using JetBrains.Annotations;
using UnityEngine;

public class Item
{
    public string Name;
    public int Worth;
    public bool CanBeSold;
    public Item(string name, string worth, string canBeSold)
    {
        Name = name;
        Worth = worth;
        CanBeSold = canBeSold;
    }
}
public class Junta : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item item = new Item();
        item.Name = "Junta";
        item.Worth = 4;
        item.CanBeSold = true;
        Debug.Log($"This {item.Name} is worth {item.Worth} golden coins");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Going to space ASAP");
        }
    }
}
