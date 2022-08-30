using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject scoreContainerView;
    public TMP_InputField nameTextfield;

    int points = 0;
    public void endGame()
    {
        scoreContainerView.SetActive(true);
    }

    public void sendScore()
    {
        new FileManager().saveScore(points, nameTextfield.text.Substring(0, 3));
        SceneManager.LoadScene(0);
    }

    public void receivePoints(int points)
    {
        this.points += points;
        scoreText.text = "Score: " + this.points;
    }

    public void playerIsHitted(int lives)
    {
        livesText.text = "Lives " + lives;
    }
}
