using UnityEngine;

public class QuestionMovement : MonoBehaviour
{
    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _tutorial;
    public static float QuestionSpeed = 5.0f;

    private void Start()
    {
        QuestionSpeed = 5.0f;
    }

    private void FixedUpdate()
    {
        if (!_lose.activeInHierarchy && !_win.activeInHierarchy && !_pause.activeInHierarchy && !_tutorial.activeInHierarchy)
        {
            transform.Translate(Vector2.left * Time.deltaTime * QuestionSpeed);
        }
    }
}
