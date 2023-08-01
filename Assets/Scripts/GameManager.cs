using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public Canvas GameOverCanvas;
    public TMP_Text healthText;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        RestartClick();
    }

    public void RestartClick()
    {
        isDead = false;
        player.reset();
        healthText.text = "x" + player.maxHealth;
        GameOverCanvas.gameObject.SetActive(false);
    }

    public void gameOver()
    {
        isDead = true;
        GameOverCanvas.gameObject.SetActive(true);
    }

    public void updateHealthText(int value)
    {
        healthText.text = "x" + value;
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

}
