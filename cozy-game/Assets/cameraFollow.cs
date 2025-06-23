using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El jugador
    public Vector3 offset = new Vector3(0, 0, -10); // Mantiene la c�mara detr�s
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
