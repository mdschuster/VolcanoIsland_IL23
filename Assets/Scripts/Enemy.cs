using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float minSpeed;
    public float maxSpeed;
    private float speed; //random speed that the enemy uses to move

    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down*speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            //play a sound
            //play a particle system
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            //destroy the fireball
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            //player to take damage
            GameManager gm = GameManager.instance();
            gm.player.takeDamage(damage);
            //destroy fireball
            Destroy(this.gameObject);
        }
        
    }
}
