using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private Touch _touch;
    private float _movementSpeed = 0.005f;
    private float _smooth = 5.0f;

    private float _tiltAroundZ;

    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            _tiltAroundZ = _touch.deltaPosition.y;
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + _touch.deltaPosition.y * _movementSpeed);   
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