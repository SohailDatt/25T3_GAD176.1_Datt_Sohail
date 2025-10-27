using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    //game object projectile
    private GameObject attackObject;

    //the point where the game object is "shot" from
    private GameObject attackPoint;

    //the speed the game object moves
    private float attackSpeed;

    public virtual void Attack()
    {
        Debug.Log("Weapon Attack!");
        GameObject attack = Instantiate(attackObject, attackPoint.transform.position, transform.rotation);
        attack.GetComponent<Rigidbody>().AddForce(transform.forward * attackSpeed);
        Destroy(attack, 0.15f);
    }
}
