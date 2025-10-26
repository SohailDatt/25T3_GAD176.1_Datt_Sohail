using UnityEngine;

public class KnifeMover : MonoBehaviour
{
    // Set these positions in the Inspector or initialize here
    public Vector3 startPosition = new Vector3(0f, 0f, 0f);
    public Vector3 endPosition = new Vector3(5f, 0f, 0f);

    // Control speed of movement
    public float moveSpeed = 2f;

    // Track whether movement should happen
    private bool isMoving = false;

    void Start()
    {
        // Initialize the object at start position
        transform.position = startPosition;
    }

    void Update()
    {
        // Listen for key press (e.g., Space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        // Move object toward end position if triggered
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);

            // Stop when we reach the end position
            if (Vector3.Distance(transform.position, endPosition) < 0.01f)
            {
                transform.position = endPosition;
                isMoving = false;
            }
        }
    }
}
