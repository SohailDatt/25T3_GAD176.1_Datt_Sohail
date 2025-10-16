using UnityEngine;

public class SimpleAiEnemy : MonoBehaviour
{
    private Rigidbody rigidbody;

    //moves towards a tarfet object
    //we need:
    // - a target object
    [SerializeField] private GameObject player;
    // - variable for how fast this moves in units per second
    [SerializeField] private float moveSpeedInUnitsPerSecond = 1f;
    // - a method for "Move()" (or even just code for this)

    private void Start()
    {

       rigidbody = GetComponent<Rigidbody>();
        // try and find the player character
        player =GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // rigidbody.MovePosition( this object's position + direction to target * speed * time.fixedDeltaTime
        // "direction to target" can be calculated with : destinationPosition - orignalPosition

        rigidbody.MovePosition(transform.position + (player.transform.position - transform.position) * moveSpeedInUnitsPerSecond * Time.deltaTime);
    }
}
