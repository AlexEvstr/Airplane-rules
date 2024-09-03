using UnityEngine;

public class TiltControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float minY = -4.5f;
    public float maxY = 4.5f;
    private float initialTilt;

    void Start()
    {
        initialTilt = Input.acceleration.x;
    }

    void Update()
    {
        if (PlaneDetector.CanMovePlane)
        {
            float tilt = Input.acceleration.x - initialTilt;

            // Если наклон влево (отрицательное значение), самолет поднимается. Если вправо (положительное значение), самолет опускается.
            Vector3 newPosition = transform.position + Vector3.up * -tilt * speed * Time.deltaTime;

            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }
    }
}
