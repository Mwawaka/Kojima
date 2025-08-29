using JetBrains.Annotations;
using UnityEngine;

public class Item
{
    public string name = "Unnamed Item";
    public int worth = 1;
    public bool canBeSold = true;
}
public class Junta : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item item = new Item();
        item.name = "Junta";
        item.worth = 4;
        item.canBeSold = true;
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
