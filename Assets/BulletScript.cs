using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool isDownwards = false;
    public GameObject player;
    
    Vector2 startPos;
    public float bulletDistance = 5f;
    void Start()
    {
        startPos = transform.position;
    }

 
    void Update()
    {
        if (Vector2.Distance(startPos, transform.position) >= bulletDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag != "Player")
        {
            if (isDownwards && collision.gameObject.tag == "Ground")
            {
                player.GetComponent<PlayerScript>().propel();
            }
            Destroy(gameObject);
        }
    }

}
