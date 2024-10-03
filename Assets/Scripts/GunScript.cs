using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    
    public float bulletTimeOffset = 0.0001f;
    public float bulletTimer = 0f;
    
    public AudioSource gunSound; 
    bool isBulletDirDown = false;

    public GameObject [] bulletColorSprites;

    void Update()
    {
        bulletTimer += Time.deltaTime;
        
        Vector2 direction = Vector2.zero;
        
        bool isBulletDirDown = false;
    
        // Check for key inputs
        if (Input.GetKey(KeyCode.W)) direction += Vector2.up; // W key for up
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down; // S key for down
            isBulletDirDown = true;
        }
    
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left; // A key for left
        else if (Input.GetKey(KeyCode.D)) direction += Vector2.right; // D key for right
    
        
        // Check if any direction key was pressed
        if (direction != Vector2.zero && bulletTimer >= bulletTimeOffset)
        {
            
            // Calculate the angle for rotation in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    
            // Apply the rotation to the bullet (rotate only on the Z-axis for 2D)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bullet.GetComponent<BulletScript>().isDownwards = isBulletDirDown;
            
            // Pick a random sprite from the array
            int colorNum = Random.Range(0, bulletColorSprites.Length);
    
            // Assign the chosen sprite to the bullet
            SpriteRenderer bulletRenderer = bullet.GetComponent<SpriteRenderer>();
            bulletRenderer.sprite = bulletColorSprites[colorNum].GetComponent<SpriteRenderer>().sprite;

            
            bulletTimer = 0f;
            
            // Play Gun Sound
            // gunSound.Play();
        }
    }
    
    // -----------------------------------------------------------------------Failed Approach
    // void Update()
    // {
    //     bulletTimer += Time.deltaTime;
    //     Vector2 direction = GetInputDirection();
    //     
    //     // Check if any direction key was pressed
    //     if (direction != Vector2.zero && bulletTimer >= bulletTimeOffset)
    //     {
    //         // Calculate the angle for rotation in degrees
    //         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //
    //         // Apply the rotation to the gun (rotate only on the Z-axis for 2D)
    //         Quaternion gunRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //         GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, gunRotation);
    //         bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //         bullet.GetComponent<BulletScript>().isDownwards = isBulletDirDown;
    //         bulletTimer = 0f;
    //     }
    //     
    // }
    //
    // Vector2 GetInputDirection()
    // {
    //     // float x = Input.GetAxis("Horizontal");
    //     // float y = Input.GetAxis("Vertical");
    //     //
    //     // if(Input.GetKey(KeyCode.W)) y = 1.0f; // Up
    //     // if(Input.GetKey(KeyCode.S)) y = -1.0f; // Down
    //     // if(Input.GetKey(KeyCode.A)) x = -1.0f; // Left
    //     // if(Input.GetKey(KeyCode.D)) x = 1.0f; // Right
    //     //
    //     float joystickX = Input.GetAxis("Horizontal");
    //     float joystickY = Input.GetAxis("Vertical");
    //     
    //     // // Use the joystick input if available, otherwise fall back to keyboard
    //     // if (joystickX != 0 || joystickY != 0)
    //     // {
    //     //     inputX = joystickX;
    //     //     inputY = joystickY;
    //     // }
    //
    //     isBulletDirDown = joystickY < 0;
    //
    //     return new Vector2(joystickX, joystickY).normalized;
    // }
    
    // --------------------------------------------------------End of failed Approch
    
    // void Update()
    // {
    //     bulletTimer += Time.deltaTime;
    //     
    //     Vector2 direction = Vector2.zero;
    //     
    //     bool isBulletDirDown = false;
    //
    //     // Check for key inputs
    //     if (Input.GetKey(KeyCode.W)) direction += Vector2.up; // W key for up
    //     else if (Input.GetKey(KeyCode.S))
    //     {
    //         direction += Vector2.down; // S key for down
    //         isBulletDirDown = true;
    //     }
    //
    //     if (Input.GetKey(KeyCode.A)) direction += Vector2.left; // A key for left
    //     else if (Input.GetKey(KeyCode.D)) direction += Vector2.right; // D key for right
    //
    //     // Check if any direction key was pressed
    //     if (direction != Vector2.zero && bulletTimer >= bulletTimeOffset)
    //     {
    //         // Calculate the angle for rotation in degrees
    //         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //
    //         // Apply the rotation to the gun (rotate only on the Z-axis for 2D)
    //         transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //         GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    //         bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //         bullet.GetComponent<BulletScript>().isDownwards = isBulletDirDown;
    //         bulletTimer = 0f;
    //     }
    //     
    // }


}
