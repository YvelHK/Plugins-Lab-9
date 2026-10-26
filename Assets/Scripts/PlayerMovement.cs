using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 6f;
    private float horizontalScreenLimit = 8.4f;

    private PlayerInput input;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Lock movement instead of wraparound to not break cinemachine
        Vector2 move = new Vector2(input.GetMoveInput().x, 0);
        if (Mathf.Abs(transform.position.x) > horizontalScreenLimit && (move.x > 0 == transform.position.x > 0))
            move.x = 0;

        transform.Translate(move * Time.deltaTime * speed);
    }
}
