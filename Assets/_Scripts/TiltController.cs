using UnityEngine;

public class TiltControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float minY = -4.5f;
    public float maxY = 4.5f;
    private float initialTilt;

    void Start()
    {
        // Запоминаем начальное положение телефона
        initialTilt = Input.acceleration.y;
    }

    void Update()
    {
        // Вычисляем отклонение от начального положения
        float tilt = Input.acceleration.y - initialTilt;
        Vector3 newPosition = transform.position + Vector3.up * tilt * speed * Time.deltaTime;

        // Ограничение по оси Y
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
}
