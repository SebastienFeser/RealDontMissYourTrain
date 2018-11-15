using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] public float playerMovementSpeed = 1.5f;
    [SerializeField] private float playerJumpForce = 20;
    private bool isGrounded;
    [SerializeField] private CapsuleCollider2D bodyColliderTrigger;
    [SerializeField] private BoxCollider2D groundCollider;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask ground;
    private float levelLimit = 8f;

    Vector2 size;

	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        size = GetComponent<BoxCollider2D>().size;
        size *= transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        //Left Right movements
        float speedx = Input.GetAxisRaw("Horizontal") * playerMovementSpeed;
        playerRigidBody.velocity = new Vector2(speedx, playerRigidBody.velocity.y);

        //Jump movements
        isGrounded = Physics2D.OverlapBox(transform.position + new Vector3(0, -size.y / 2, 0), new Vector2(size.x, 0.05f), 0, ground );
        if(isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerRigidBody.AddForce(new Vector2(0, playerJumpForce));               
            }
            
        }

        //Level Limit
        if (transform.position.x >= levelLimit)
            {
                transform.position = new Vector2(levelLimit, transform.position.y);
            }
        if (transform.position.x <= -levelLimit)
            {
                transform.position = new Vector2(-levelLimit, transform.position.y);
            }
         
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { 
            if (Input.GetButtonDown("Jump"))
            {
                playerRigidBody.AddForce(new Vector2(playerRigidBody.velocity.x, playerJumpForce));
            }
        }
    }

   

}
