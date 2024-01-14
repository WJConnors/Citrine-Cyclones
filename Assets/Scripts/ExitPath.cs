using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPath : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private int playersInExit = 0;
    private const int PLAYERS_NEEDED_IN_EXIT = 2;
    private int amtOfScenes = 4;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(PLAYER_TAG))
            return;

        playersInExit++;

        if(playersInExit == PLAYERS_NEEDED_IN_EXIT)
        {
            GoToNextLevel();
        }
    }

    private void GoToNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        if(currentScene == amtOfScenes)
        {
            //no more next scene 
            //you win game
            FindObjectOfType<EndGame>().ShowPanel();
        }
        SceneManager.LoadScene(currentScene);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(PLAYER_TAG))
            return;

        playersInExit--;
    }

    private void Update()
    {
        //debuging help
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(2);
        }
    }
}
