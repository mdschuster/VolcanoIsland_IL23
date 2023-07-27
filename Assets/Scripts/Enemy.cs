using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float minSpeed;
    public float maxSpeed;
    private float speed; //random speed that the enemy uses to move
    
    
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
}
