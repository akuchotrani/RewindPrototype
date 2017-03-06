using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 0.0f;
    public float playerJumpForce = 0.0f;
    private Rigidbody2D playerRigidBody;
    public bool isGrounded = true;

    public Sprite whiteSprite;
    bool isWhiteSpriteON;
    bool isBlackSpriteON;
    public Sprite blackSprite;

    private SpriteRenderer spriteRenderer;

    private BoxCollider2D collider;
    // Use this for initialization
    void Start ()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<BoxCollider2D>();
        isWhiteSpriteON = true;
        isBlackSpriteON = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isWhiteSpriteON)
        {
            spriteRenderer.sprite = blackSprite;
            isBlackSpriteON = true;
            isWhiteSpriteON = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isBlackSpriteON)
        {
            spriteRenderer.sprite = whiteSprite;
            isWhiteSpriteON = true;
            isBlackSpriteON = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true || Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            playerRigidBody.AddForce(Vector2.up * playerJumpForce);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        { 
            transform.Translate(new Vector3(-playerMoveSpeed, 0, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(playerMoveSpeed, 0, 0) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "WhitePlatform" || collision.collider.tag == "BlackPlatform" && isGrounded == false)
        {
            // Debug.Log("collided with platform");
            isGrounded = true;
        }

        if (collision.collider.tag == "BlackWall")
        {
            if (isBlackSpriteON == false)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 5.0f);
            }
        }

        if (collision.collider.tag == "WhiteWall")
        {
            if (isWhiteSpriteON == false)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 5.0f);
            }
        }

        if (collision.collider.tag == "WhitePlatform")
        {
            // Debug.Log("collided with white platform");
            if (isWhiteSpriteON == true)
            {
                collider.isTrigger = true;
                Invoke("DisableTrigger", 0.5f);
            }
            else
            {
                collider.isTrigger = false;
            }
        }

        if (collision.collider.tag == "BlackPlatform")
        {
           // Debug.Log("collided with black platform");
            if (isBlackSpriteON == true)
            {
                collider.isTrigger = true;
                Invoke("DisableTrigger", 0.5f);

            }
            else
            {
                collider.isTrigger = false;
            }
        }


        if (collision.collider.tag == "Enemy")
        {
            Destroy(collider.gameObject);
            //collider.gameObject.SetActive(false);
        }
    
    }


    private void DisableTrigger()
    {
        this.collider.isTrigger = false;
    }

}
