using wordList;
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
        public int counter = 1;
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
        public GameObject gameOver;
        public GameObject MainAudio;
        public GameObject GameOverCanvas;
        public GameObject PausePerTurn;
        InputField input;
        public float number;
        public List<string> wordlist;
        int wordLength = 100; //restriction on the length of the word. 100 means no restriction
        //Etong wordLength yung need magbago-bago ng values gamit yung sa dropdown

        void Awake()
        {
            input = GameObject.Find("inputField").GetComponent<InputField>();
            input.characterLimit = wordLength; //limits the number of character in the input field
        }
        

        void Start()
        {
            startingTime1 = PlayerPrefs.GetFloat("time1");
            startingTime2 = PlayerPrefs.GetFloat("time2");
            number = PlayerPrefs.GetFloat("time2");
            playerIndicator.GetComponent<Text>().text = "Player 1";
            referenceWord = GetRandomWord(); // gets random word
            outputField.GetComponent<Text>().text = referenceWord;
            RemoveWord(referenceWord);
            StartCoroutine("Timer1");
            StartCoroutine("Timer2");
            counter++;

        }
        /*private void Update()
        {
            if (Input.GetKey("return") && GameOverCanvas.activeInHierarchy == false)
            {
                StoreWord();
                CheckWord();
            }
        }*/
        public List<string> ReadTextFile()
        {
            string[] wordarray = WordsList.listOfWords;
            wordlist = new List<string>(wordarray);

            return wordlist;
        }

        public string GetRandomWord()
        {
            var random = new System.Random(); //making instance to be able to used certain methods of it
            var _words = ReadTextFile(); //calls the ReadTextFile method
            int index = random.Next(_words.Count); //generates a random number based on the item's count in the list
            string randomWord = _words[index]; //uses the random number as index to produce a random word from the word list

            return randomWord;
        }
        public void RemoveWord(string removeWord)
        {
            wordlist.Remove(removeWord); //removes a word from the list
        }

        public void StoreWord()
        {
            inputWord = (inputField.GetComponent<Text>().text).ToLower(); //receives the input and converts it to lowercase
            input.text = "";
            timer2 = startingTime2;
            counter++;
            PausePerTurn.SetActive(true);
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
                 && wordlist.Contains(inputWord))                //for valid inputword
            {
                if (wordLength == 100) //for "no restriction" mode
                {
                    RemoveWord(inputWord); //remove the input word to avoid repetition
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
                }
                else //for "with restriction" mode
                {
                    if (inputWord.Length == wordLength)
                    {
                        RemoveWord(inputWord); //remove the input word to avoid repetition
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

                    }

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
            GameOverCanvas.SetActive(true);
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
                    PausePerTurn.SetActive(true);
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
            PausePerTurn.SetActive(false);

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
            GameOverCanvas.SetActive(true);
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