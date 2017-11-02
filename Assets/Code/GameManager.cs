using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    void OnAwake()
    {
        CheckForGameManager();
    }

    private void CheckForGameManager()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Player player = new Player("Mads");
        Debug.Log("Score: " + player.Score);
        player.AddScore(10);
        Debug.Log("Score: " + player.Score);
    }
}
