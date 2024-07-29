using UnityEngine;

public class QuestionMovement : MonoBehaviour
{
    public static float QuestionSpeed = 5.0f;
    private void Start()
    {
        QuestionSpeed = 5.0f;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.deltaTime * QuestionSpeed);
    }
}
