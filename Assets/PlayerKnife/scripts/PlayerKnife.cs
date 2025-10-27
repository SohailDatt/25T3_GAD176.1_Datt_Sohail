using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

public class PlayerKnife : WeaponParent
{
    private StarterAssetsInputs _input;

    [SerializeField]
    private GameObject knifeSlash;
    [SerializeField]
    private GameObject knifePoint;
    [SerializeField]
    private float slashSpeed = 850;

    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (_input.attack)
        {
            Attack();
            _input.attack = false;
            
        }
    }

    //inhertiating attack from weaponparent and overriding it for playerknife
    public override void Attack()
    {
        Debug.Log("Knife Attack!");
        GameObject slash = Instantiate(knifeSlash, knifePoint.transform.position, transform.rotation);
        slash.GetComponent<Rigidbody>().AddForce(transform.forward * slashSpeed);
        Destroy(slash, 0.15f);
    }

}
