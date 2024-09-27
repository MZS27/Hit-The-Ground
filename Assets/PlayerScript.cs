using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    
    float movementSpeed = 7.5f;
    private float jumpDistance = 10f;
    private float propelDistance = 5f;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
            rigidbody.velocity = new Vector2(-movementSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
            rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
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

        lockRotation();

        // float horizontalMove = Input.GetAxisRaw("Horizontal");
        // rigidbody.velocity = new Vector2(horizontalMove * movementSpeed, rigidbody.velocity.y);
        // if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        // {
        //     transform.Translate(Vector2.up * Time.deltaTime * jumpDistance);
        // }
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
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, propelDistance);
    }
}
