using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    //Singleton stuff
    private static MusicManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this);
    }

    public static MusicManager instance()
    {
        return _instance;
    }


    private AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source.isPlaying == false)
        {
            source.Play();
        }
    }

}
