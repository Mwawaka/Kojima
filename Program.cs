using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    public Vector3 RotationPerSecond;
    void Update()
    {
        transform.Rotate(RotationPerSecond * Time.deltaTime, 2.3f);
    }
}