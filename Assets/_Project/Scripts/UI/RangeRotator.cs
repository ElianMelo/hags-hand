using UnityEngine;

public class RangeRotator : MonoBehaviour
{
    public float rotateAmount;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotateAmount));
    }
}
