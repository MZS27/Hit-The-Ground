using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    
    public float bulletTimeOffset = 0.0001f;
    public float bulletTimer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
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

            // Apply the rotation to the gun (rotate only on the Z-axis for 2D)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bullet.GetComponent<BulletScript>().isDownwards = isBulletDirDown;
            bulletTimer = 0f;
        }
        
    }


}
