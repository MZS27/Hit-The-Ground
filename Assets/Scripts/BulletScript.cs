using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletScript : MonoBehaviour
{
    public bool isDownwards = false;
    public GameObject player;
    // public GameObject [] bulletColorSprites;
    
    Vector2 startPos;
    public float bulletDistance = 5f;
    void Start()
    {
        startPos = transform.position;
        // pickColor();
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

    // public void pickColor()
    // {
    //     int colorNum = Random.Range(0, bulletColorSprites.Length);
    //     Debug.Log(colorNum);
    //     bulletColorSprites[colorNum].SetActive(true);
    // }

}
