using _Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace _Checker
{
    public class VersusWordChecker : MonoBehaviour
    {
        public string inputWord;
        public string referenceWord;
        string player;
        public float time;
        int msecs1;
        int secs1;
        int mins1;
        int secs2;
        float timer2;
        float timer1;
        public int scoreP1;
        public int scoreP2;
        public int counter;
        bool isPaused1 = false;
        bool isPaused2 = false;
        [SerializeField] public float startingTime2;
        [SerializeField] public float startingTime1; //For IEnumrator Timer
        [SerializeField] Text timerText1;
        [SerializeField] Text timerText2;
        public GameObject inputField;
        public GameObject outputField;
        public GameObject scoreObjectP1;
        public GameObject scoreObjectP2;
        public GameObject playerIndicator;
        //public GameObject inputFieldText;
        public GameObject continueButton;
        public GameObject surrenderButton;
        public GameObject areYouReady;
        public GameObject pauseBG;
        public GameObject rematchButton;
        public GameObject mainmenuButton;
        public GameObject quitButton;
        public GameObject congrats;
        public GameObject gameOver;
        public GameObject gameOverBG;
        public GameObject gameOverMusic;
        public GameObject MainAudio;
        InputField input;
        public float number;
        void Awake()
        {
            input = GameObject.Find("inputField").GetComponent<InputField>();
        }
        

        void Start()
        {
            startingTime1 = PlayerPrefs.GetFloat("time1");
            startingTime2 = PlayerPrefs.GetFloat("time2");
            number = PlayerPrefs.GetFloat("time2");
            playerIndicator.GetComponent<Text>().text = "Player 1";
            referenceWord = VersusWordManager.GetRandomWord(); // gets random word
            outputField.GetComponent<Text>().text = referenceWord;
            VersusWordManager.RemoveWord(referenceWord);
            StartCoroutine("Timer1");
            StartCoroutine("Timer2");
            continueButton.SetActive(false);
            surrenderButton.SetActive(false);
            pauseBG.SetActive(false);
            areYouReady.SetActive(false);
            rematchButton.SetActive(false);
            mainmenuButton.SetActive(false);
            quitButton.SetActive(false);
            congrats.SetActive(false);
            gameOver.SetActive(false);
            gameOverBG.SetActive(false);
            gameOverMusic.SetActive(false);
            counter++;

        }

        public void StoreWord()
        {
            inputWord = (inputField.GetComponent<Text>().text).ToLower(); //receives the input and converts it to lowercase
            input.text = "";
            timer2 = startingTime2;
            counter++;
            continueButton.SetActive(true);
            surrenderButton.SetActive(true);
            pauseBG.SetActive(true);
            areYouReady.SetActive(true);
            isPaused1 = true;
            isPaused2 = true;

        }
        public void CheckWord()
        {
            
            if (inputWord == "")
            {
                outputField.GetComponent<Text>().text = referenceWord;
                if (counter % 2 != 0)
                {
                    player = "Player 2";
                    //playerIndicator.GetComponent<Text>().text = "Player 2"; //indicates the it is the turn of Player 2
                }
                else
                {
                    player = "Player 1";
                    //playerIndicator.GetComponent<Text>().text = "Player 1"; //indicates the it is the turn of Player 1
                }
                playerIndicator.GetComponent<Text>().text = player;
            }

            else if (referenceWord[referenceWord.Length - 1] == inputWord[0] //index: referenceWord.Length - 1 
                 && VersusWordManager.wordList.Contains(inputWord))                //for valid inputword
            {
                VersusWordManager.RemoveWord(inputWord); //remove the input word to avoid repetition
                referenceWord = inputWord; //makes the input word to be the reference word
                outputField.GetComponent<Text>().text = referenceWord; //display the new value of reference word
                if (counter % 2 != 0) //decides whether player 1 or player 2
                {
                    player = "Player 2";
                    //playerIndicator.GetComponent<Text>().text = "Player 2"; //indicates the it is the turn of Player 2
                    scoreP1 += inputWord.Length; //adds the score of Player 2 depending on length of words
                    scoreObjectP1.GetComponent<Text>().text = scoreP1.ToString(); //display the current score of Player 2 
                }
                else
                {
                    player = "Player 1";
                    //playerIndicator.GetComponent<Text>().text = "Player 1"; //indicates the it is the turn of Player 1
                    scoreP2 += inputWord.Length; //adds the score of Player 1 depending on length of words
                    scoreObjectP2.GetComponent<Text>().text = scoreP2.ToString(); //display the current score of Player 1
                }
                playerIndicator.GetComponent<Text>().text = player;

            }

            else //for invalid input word
            {
                outputField.GetComponent<Text>().text = referenceWord;
                if (counter % 2 != 0)
                {
                    player = "Player 2";
                    //playerIndicator.GetComponent<Text>().text = "Player 2"; //indicates the it is the turn of Player 2    
                }
                else
                {
                    player = "Player 1";
                    //playerIndicator.GetComponent<Text>().text = "Player 1"; //indicates the it is the turn of Player 1
                }
                playerIndicator.GetComponent<Text>().text = player;
            }
            


        }
        IEnumerator Timer1() //game time
        {
            timer1 = startingTime1;
            do
            {
                timer1 -= Time.deltaTime;
                msecs1 = (int)((timer1 - (int)timer1) * 100);
                secs1 = (int)(timer1 % 60);
                mins1 = (int)(timer1 / 60) % 60;

                while (isPaused1)
                {
                    yield return null;
                }

                timerText1.text = string.Format("{0:00}:{1:00}:{2:00}", mins1, secs1, msecs1);

                yield return null;
            }
            while (timer1 > 0);
            timer2 = 0;
            timerText2.text = string.Format("{0}", timer2);

            if (scoreP1 > scoreP2)
            {
                gameOver.GetComponent<Text>().text = "PLAYER 1 WINS!";
            }
            else if (scoreP1 == scoreP2)
            {
                gameOver.GetComponent<Text>().text = "DRAW!";
            }
            else
            {
                gameOver.GetComponent<Text>().text = "PLAYER 2 WINS!";
            }
            rematchButton.SetActive(true);
            mainmenuButton.SetActive(true);
            quitButton.SetActive(true);
            congrats.SetActive(true);
            gameOver.SetActive(true);
            gameOverBG.SetActive(true);
            gameOverMusic.SetActive(true);
            MainAudio.SetActive(false);
        }
        IEnumerator Timer2() //timer per turn
        {
            
            timer2 = startingTime2;
            do
            {
                timer2 -= Time.deltaTime;
                secs2 = (int)(timer2 % 60);
                if (timer2 <= 0)
                {
                    counter++;
                    timer2 = startingTime2;
                    continueButton.SetActive(true);
                    surrenderButton.SetActive(true);
                    pauseBG.SetActive(true);
                    areYouReady.SetActive(true);
                    isPaused1 = true;
                    isPaused2 = true;
                    if (counter % 2 != 0)
                    {
                        player = "Player 2";
                        //playerIndicator.GetComponent<Text>().text = "Player 2"; //indicates the it is the turn of Player 2    
                    }
                    else
                    {
                        player = "Player 1";
                        //playerIndicator.GetComponent<Text>().text = "Player 1"; //indicates the it is the turn of Player 1
                    }
                    playerIndicator.GetComponent<Text>().text = player;
                }
                while (isPaused2)
                {
                    timerText2.text = string.Format("{0}", "");
                    yield return null;
                }

                timerText2.text = string.Format("{0}", secs2);

                yield return null;
            }
            while (timer2 > 0);
    

        }
        public void Continue()
        {
            input.text = "";
            isPaused1 = false;
            isPaused2 = false;
            continueButton.SetActive(false);
            surrenderButton.SetActive(false);
            pauseBG.SetActive(false);
            areYouReady.SetActive(false);

        }
        public void Surrender()
        {
            if (player == "Player 1")
            {
                gameOver.GetComponent<Text>().text = "PLAYER 2 WINS!";
            }
            else
            {
                gameOver.GetComponent<Text>().text = "PLAYER 1 WINS!";
            }
            rematchButton.SetActive(true);
            mainmenuButton.SetActive(true);
            quitButton.SetActive(true);
            congrats.SetActive(true);
            gameOver.SetActive(true);
            gameOverBG.SetActive(true);
            gameOverMusic.SetActive(true);
            MainAudio.SetActive(false);

        }
        public void Rematch()
        {
            SceneManager.LoadScene("VersusScene");
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}