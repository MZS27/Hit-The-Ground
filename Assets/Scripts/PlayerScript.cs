using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    enum SpriteCodes
    {
        SIDE,
        UP,
        DOWN,
        DIAGONAL_UP,
        DIAGONAL_DOWN,
    };
    public GameObject[] spritesPlayer;
    private bool isFacingLeft = false; // To track the current direction

    private Rigidbody2D rigidbody;
    
    float movementSpeed = 7.5f;
    private float jumpDistance = 10f;
    private float propelDistance = 5f;
    bool isGrounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
            rigidbody.velocity = new Vector2(-movementSpeed, rigidbody.velocity.y);
            FlipCharacter(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
            rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
            FlipCharacter(false);
        }
        else
        {
            // Stop horizontal movement when no keys are pressed. Stops player from sliding around for no reason.
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpDistance );
        }

        animateCharacter();
        lockRotation();
        
    }

    //This is not an ideal implementation
    void animateCharacter()
    {
        // Disable all sprites first
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            DisableAllSprites();
        }
        else return;
        // Check input and activate the correct sprite
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            spritesPlayer[(int)SpriteCodes.DIAGONAL_UP].SetActive(true);
            FlipCharacter(false); // Facing right
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            spritesPlayer[(int)SpriteCodes.DIAGONAL_DOWN].SetActive(true);
            FlipCharacter(false); // Facing right
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            spritesPlayer[(int)SpriteCodes.DIAGONAL_UP].SetActive(true);
            FlipCharacter(true); // Facing left
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            spritesPlayer[(int)SpriteCodes.DIAGONAL_DOWN].SetActive(true);
            FlipCharacter(true); // Facing left
        }
        else if (Input.GetKey(KeyCode.S))
        {
            spritesPlayer[(int)SpriteCodes.DOWN].SetActive(true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            spritesPlayer[(int)SpriteCodes.UP].SetActive(true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spritesPlayer[(int)SpriteCodes.SIDE].SetActive(true);
            FlipCharacter(false); // Facing right
        }
        else if (Input.GetKey(KeyCode.A))
        {
            spritesPlayer[(int)SpriteCodes.SIDE].SetActive(true);
            FlipCharacter(true); // Facing left
        }
    }

    void DisableAllSprites()
    {
        foreach (GameObject sprite in spritesPlayer)
        {
            sprite.SetActive(false); // Disable all sprites
        }
    }

// Flip the character's sprite horizontally
    void FlipCharacter(bool faceLeft)
    {
        if (isFacingLeft != faceLeft)
        {
            Vector3 scale = spritesPlayer[(int)SpriteCodes.SIDE].transform.localScale;
            scale.x *= -1; // Flip the x-axis
            foreach (GameObject sprite in spritesPlayer)
            {
                sprite.transform.localScale = scale; // Apply the flipped scale to each sprite
            }
            isFacingLeft = faceLeft; // Update facing direction
        }
    }
    private void OnCollisionEnter2D(Collision2D colObj)
    {
        if (colObj.gameObject.tag == "Ground" || colObj.gameObject.tag == "Bullet")
        {
            isGrounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D colObj)
    {
        if (colObj.gameObject.tag == "Ground" || colObj.gameObject.tag == "Bullet")
        {
            isGrounded = false;
        }
    }

    void lockRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void propel()
    {
        // rigidbody.velocity = new Vector2(0, propelDistance);
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, propelDistance);
        
        
    }
    

}
