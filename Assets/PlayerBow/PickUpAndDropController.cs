using UnityEngine;

public class PickUpAndDropController : MonoBehaviour
{
    public PlayerBow bowScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    private void Start()
    {

        if (!equipped)
        {
            bowScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            bowScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }

    }

    private void Update()
    {

        //check if the player is in range and if "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }

        //drop the weapon if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }

    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //make the weapon a child of the camera and move it to default position
        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;



        //make the rigidbody kinematic and Boxcollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable the bow script when equipped
        bowScript.enabled = true;

    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //set parent to null
        transform.SetParent(null);


        //make the rigidbody Not kinematic and Boxcollider a trigger
        rb.isKinematic = false;
        coll.isTrigger = false;


        //add force
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        //disable the bow script when equipped
        bowScript.enabled = false;

    }
}
