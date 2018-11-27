using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
    private Rigidbody2D playerRigidBody;
    [SerializeField] public float playerMovementSpeed = 1.5f;
    [SerializeField] private float playerJumpForce = 20;
    private bool isGrounded;
    [SerializeField] private CapsuleCollider2D bodyColliderTrigger;
    [SerializeField] private BoxCollider2D groundCollider;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask ground;
    private float levelLimit = 8f;  //the limits where the player can move right or left
    private Animator playerAnimator;
    private PlayerScript playerScript;

    private bool jumpButtonPressed = false;

    private float jumpBoxSize = 0.05f;


    Vector2 size;

	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        size = GetComponent<BoxCollider2D>().size;
        size *= transform.localScale;
        playerAnimator = GetComponentInChildren<Animator>();
        playerScript = FindObjectOfType<PlayerScript>();
    }
	
	void Update () {
        //Left Right movements
        float speedx = Input.GetAxisRaw("Horizontal") * playerMovementSpeed;
        playerRigidBody.velocity = new Vector2(speedx, playerRigidBody.velocity.y);

        //Jump Box
        isGrounded = Physics2D.OverlapBox(transform.position + new Vector3(0, -size.y / 2, 0), new Vector2(size.x, jumpBoxSize), 0, ground);
        if(isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpButtonPressed = true;             
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

        //Punch
        if (playerScript.playerState == PlayerScript.PlayerOnEnemyStates.NORMAL)
        {
            if (Input.GetButtonDown("Punch"))
            {

                playerScript.playerState = PlayerScript.PlayerOnEnemyStates.PUNCH;

            }
            
        }
        if (playerScript.playerState == PlayerScript.PlayerOnEnemyStates.PUNCH)
        {
            if (Input.GetButtonUp("Punch"))
                    {

                        playerScript.playerState = PlayerScript.PlayerOnEnemyStates.UNPUNCH;
                    }
        }
         
        
    }

    private void FixedUpdate()
    {
        if (jumpButtonPressed)
        {
            playerRigidBody.AddForce(new Vector2(0, playerJumpForce));
            jumpButtonPressed = false;
        }
    }




}
