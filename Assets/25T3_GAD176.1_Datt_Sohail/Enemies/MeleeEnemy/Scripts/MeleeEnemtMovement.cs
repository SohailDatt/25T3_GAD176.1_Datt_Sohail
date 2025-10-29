using UnityEngine;






public class MeleeEnemtMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    
    public float moveSpeed = 3f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    
    private bool isPlayerInAttackRange;


    //moves towards a target object
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // rigidbody.MovePosition( this object's position + direction to target * speed * time.fixedDeltaTime
        // "direction to target" can be calculated with : destinationPosition - orignalPosition

        
        
        if (player == null) return;

        if (!isPlayerInAttackRange)
        {
            rigidbody.MovePosition(transform.position + (player.transform.position - transform.position) * moveSpeedInUnitsPerSecond * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInAttackRange = true;
            Attack(other.GetComponent<Player>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInAttackRange = false;
        }
    }

    void Attack(Player player)
    {
        if (Time.time > lastAttackTime + attackCooldown)
        {
            // Perform the attack
            Debug.Log("Enemy Attacked!");

            // Deal damage to the player
            if (player != null)
            {
                player.TakeDamage();
            }

            lastAttackTime = Time.time;
        }
    }
}
