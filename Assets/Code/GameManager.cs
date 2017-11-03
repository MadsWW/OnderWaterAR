using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private static GameManager gameManager;
    
    public static Player player;



    private void OnAwake()
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


    //!!Make CheckForPlayer later, if there is non, let the player create one.!!
    private void CreatePlayer(string name)
    {
        if (player == null)
        {
            player = new Player(name);
        } else if (player != null)
        {
            Debug.Log("A player already exists, called: " + player.Name );
        }
    }
}
