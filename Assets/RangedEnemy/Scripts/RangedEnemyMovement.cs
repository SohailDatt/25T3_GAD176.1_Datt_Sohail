using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    // Distance the enemy will move back and forth
    public float moveDistance = 5f;
    // Speed of movement
    public float moveSpeed = 2f;
    // Starting position of the enemy
    private Vector3 startPos;

    void Start()
    {
        // Store the initial position of the enemy
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate new X position using PingPong
        float newX = Mathf.PingPong(Time.time * moveSpeed, moveDistance) + startPos.x;
        // Apply movement to enemy
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }

}
