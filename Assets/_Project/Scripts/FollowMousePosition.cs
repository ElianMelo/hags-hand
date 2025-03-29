using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    void Update()
    {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        transform.position = new Vector3(v3.x, transform.position.y, v3.z);
    }
}
