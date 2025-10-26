using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

public class PlayerKnife : MonoBehaviour
{
    private StarterAssetsInputs _input;

    //moving the knife
    public Vector3 startPosition = new Vector3(0f, 0f, 0f);
    public Vector3 endPosition = new Vector3(0f, 0f, 0f);

    public float moveSpeed = 3f;

    private bool isMoving = false;

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
            isMoving = true;
        }
    }

    void Attack()
    {
        Debug.Log("Attack");

    }

}
