using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkspeed = 20.0f;
    private Rigidbody2D rigidbody2d;
    [SerializeField] private LayerMask layerMask;
    private BoxCollider2D boxCollider2d;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        move();

        shoot();

    }

    private void shoot()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position , Vector2.right, layerMask);
        if (hit.collider != null)
        {

            Destroy(hit.transform.gameObject);

        }


    }

    void move()
    {

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody2d.MovePosition(rigidbody2d.position + input * Time.deltaTime * walkspeed);


    }

}
