using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WordCheck;

public class HighScore : MonoBehaviour
{
    
    public Text highScore2;
    public Text scoreText;
    public Text shadowScoreText;
    public int currentScore1;
    public GameObject gameOver;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject bgGameOver;
    
/*
    void Start()
    {
        
        currentScore1 = PlayerPrefs.GetInt("score");
        scoreText.text = "S C O R E:" + PlayerPrefs.GetInt("score");
        
        gameOver.GetComponent<Text>().text = "GAME OVER\nWould You like to try again?";
        if(currentScore1 > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentScore1);
            highScore2.text = "H I G H S C O R E: "   + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highScore2.text = "H I G H S C O R E: "   + PlayerPrefs.GetInt("highscore");
        }
    }
*/
    void Update()
    {
        currentScore1 = PlayerPrefs.GetInt("score");
        scoreText.text = "" + PlayerPrefs.GetInt("score");
        
        gameOver.GetComponent<Text>().text = "GAME OVER\nWould You like to try again?";
        if(currentScore1 > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentScore1);
            highScore2.text = "Highscore \n"   + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highScore2.text = "Highscore \n"   + PlayerPrefs.GetInt("highscore");
        }
    }




}
