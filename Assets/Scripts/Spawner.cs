using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    private float timer;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timeBetweenSpawns)
        {
            //do spawning
            float x = Random.Range(-7.5f, 7.5f);
            Vector3 pos = new Vector3(x,6f,0f);
            Instantiate(enemy,pos,Quaternion.identity);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
