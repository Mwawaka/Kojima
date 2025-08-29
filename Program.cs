using JetBrains.Annotations;
using UnityEngine;

public class Item
{
    public string Name{ get; set; } = "Unnamed Item";
    public int Worth = 1;
    public bool CanBeSold = true;
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
