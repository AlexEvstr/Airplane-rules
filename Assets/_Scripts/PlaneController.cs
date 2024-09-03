using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private Transform _plane;
    private float speed = 5f;
    private float minY = -4.5f;
    private float maxY = 4.5f;

    public void Update()
    {
        if (PlaneDetector.CanMovePlane)
        {
            float verticalInput = _fixedJoystick.Vertical;

            Vector3 direction = new Vector3(0, verticalInput, 0).normalized;

            _plane.position += direction * speed * Time.deltaTime;

            _plane.position = new Vector3(
                _plane.position.x,
                Mathf.Clamp(_plane.position.y, minY, maxY),
                _plane.position.z
            );
        }
    }
}
