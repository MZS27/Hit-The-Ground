using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool isDownwards = false;
    public GameObject player;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDownwards)
        {
            player.GetComponent<PlayerScript>().propel();
        }
        if(collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}
