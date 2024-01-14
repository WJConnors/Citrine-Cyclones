using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;

    public void ShowPanel()
    {
        endGamePanel.SetActive(true);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
