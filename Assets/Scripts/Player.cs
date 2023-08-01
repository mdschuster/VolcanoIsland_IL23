using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public float speed;
    public int maxHealth;
    private float input;
    private Rigidbody2D rigidbody;
    private Animator anim;
    private int health; //current health of the player
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public void reset()
    {
        health = maxHealth; //reset health to max
        Vector3 pos = new Vector3(0f, -3.65f, 0f);
        this.transform.position = pos; //move to default pos
        this.gameObject.SetActive(true); //turn on object
    }

    public void takeDamage(int amount)
    {
        //subtract the damage taken from current health
        health -= amount;
        GameManager.instance().updateHealthText(health);
        if (health <= 0)
        {
            //die
            //play a sound
            //do something with the UI
            //play a particle effect
            //disable the player object
            GameManager.instance().gameOver();
            this.gameObject.SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transitioning from idle to run or vice versa
        if (input != 0)
        {
            anim.SetBool("isRunning",true);
        }
        else
        {
            anim.SetBool("isRunning",false);
        }
        //face the correct direction
        if (input < 0) //left
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (input > 0) //right
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        
    }

    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        float xVel = speed * input;
        Vector2 vel = new Vector2(xVel, 0);
        rigidbody.velocity = vel;
    }
}
