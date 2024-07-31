using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private Touch _touch;
    private float _movementSpeed = 0.005f;
    private float _smooth = 5.0f;
    private float _tiltAroundZ;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            _tiltAroundZ = _touch.deltaPosition.y;

            if (_touch.phase == TouchPhase.Moved)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + _touch.deltaPosition.y * _movementSpeed);
                newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
                transform.position = newPosition;
            }
        }
        else
        {
            _tiltAroundZ = 0;
        }

        Quaternion target = Quaternion.Euler(0, 0, _tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
    }
}
