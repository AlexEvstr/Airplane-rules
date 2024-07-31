using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _tutorial;
    private float _bgSpeed = 2.0f;
    private Vector2 _startPosition;
    private float _halfWigth;

    private void Start()
    {
        _startPosition = transform.position;
        _halfWigth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void FixedUpdate()
    {
        if (!_lose.activeInHierarchy && !_win.activeInHierarchy && !_pause.activeInHierarchy && !_tutorial.activeInHierarchy)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _bgSpeed);

            if (transform.position.x < (_startPosition.x - _halfWigth))
            {
                transform.position = _startPosition;
            }
        }
    }
}