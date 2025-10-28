using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

public class PlayerBow : WeaponParent
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private GameObject arrowPoint;
    [SerializeField]
    private float arrowSpeed = 850f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.attack)
        {
            Attack();
            _input.attack = false;
        }
    }

    public override void Attack()
    {
        Debug.Log("Shoot!");
        GameObject arrow = Instantiate(arrowPrefab, arrowPoint.transform.position, transform.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowSpeed);
        Destroy(arrow, 0.75f);
    }

    
}
