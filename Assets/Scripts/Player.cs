using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed;
    public int maxHealth;
    private float input;
    private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        float xVel = speed * input;
        Vector2 vel = new Vector2(xVel, 0);
        rigidbody.velocity = vel;
    }
}
