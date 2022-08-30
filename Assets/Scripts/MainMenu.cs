using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        string scores = new FileManager().getStringScores();
        scoreText.text = scores;
    }

    public void initGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
