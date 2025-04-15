using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;// Library to restart the phase

// This file is in a empty object to control the game score
public class GameController : MonoBehaviour
{
    // static method to be able to access it through another script
    public int totalScore;

    public Text scoreText;

    // Refers the game over panel
    public GameObject gameOver;

    public static GameController instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // variable created and attributed to the script itself
        instance = this;
    }

    // method to upload the score
    public void UpdateScoreText()
    {
        // Transforming the int value into a text
        scoreText.text = totalScore.ToString();
    }

    // Show the game over panel 
    public void ShowGameOver()
    {
        // To activate the game over panel
        gameOver.SetActive(true);
    }

    // Restarting the phase. Method called just when
    // the restart button is pressed
    public void RestartGame(string lvlName)
    {
        // Give the name of the phase as the variable
        SceneManager.LoadScene(lvlName);
    }

}
