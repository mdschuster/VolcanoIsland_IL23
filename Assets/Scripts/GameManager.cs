using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton Part
    private static GameManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player.reset();
    }

}
