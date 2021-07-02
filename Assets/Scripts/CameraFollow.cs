using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothness;
    public GameObject targetObject;

    private Vector3 initalOffset;
    private Vector3 cameraPosition;
    private Rigidbody2D targetRb2d;
    

    void Start()
    {
        initalOffset = transform.position - targetObject.transform.position;
        targetRb2d = targetObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.transform.position + initalOffset + new Vector3(targetRb2d.velocity.x / smoothness, targetRb2d.velocity.y / smoothness, 0);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
    }
}