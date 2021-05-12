using System.Collections;
using System.Collections.Generic;
using wordList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace WordCheck
{
    public class WordChecker : MonoBehaviour
    {
        public string inputWord;
        public string referenceWord;
        public int score;      
        [SerializeField] float startingTime = 9f;
        [SerializeField] TextMeshProUGUI timerText;
        float timer;
        float seconds;
        float miliseconds;
        public GameObject inputField;
        public GameObject outputField;
        public GameObject gameOver;
        public GameObject scoreObject;
        public GameObject audio;
        public InputField input;
        public List<string> wordlist;

        void Awake()
        {
            input = GameObject.Find("inputField").GetComponent<InputField>();
        }


        void Start()
        {
            referenceWord = GetRandomWord(); // gets random word
            outputField.GetComponent<Text>().text = referenceWord;
            RemoveWord(referenceWord);
            StartCoroutine(Timer());
            PlayerPrefs.SetInt("score", 0);
            score = 0;
            //gameOver.SetActive(false);
            audio.SetActive(true);
            
        }
        /*private void Update()
        {
            if (Input.GetKey("return") && gameOver.activeInHierarchy == false)
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
            inputWord = (inputField.GetComponent<Text>().text).ToLower(); // add ToLower later 
            input.text = "";
            timer = startingTime - 1;
        }
        public void CheckWord()
        {
            if (inputWord == "")
            {
                GameEnder();
            }
            else if (referenceWord[referenceWord.Length - 1] == inputWord[0] //index: referenceWord.Length - 1
                && wordlist.Contains(inputWord))
            {
                RemoveWord(inputWord); //remove the input word to avoid repetition
                referenceWord = inputWord; //makes the input word to be the reference word
                outputField.GetComponent<Text>().text = referenceWord;
                score += inputWord.Length;
                scoreObject.GetComponent<Text>().text = score.ToString();
                PlayerPrefs.SetInt("score", score);
                
            }
            else
            {
                GameEnder();
            }
        }

        
        void GameEnder()
        {
            PlayerPrefs.SetInt("score", score);
            gameOver.SetActive(true);
            audio.SetActive(false);
            
        }
        
        IEnumerator Timer()
        {
            timer = startingTime - 1;
            do
            {
                timer -= Time.deltaTime;
                miliseconds = (int)((timer - (int)timer) * 100);
                seconds = (timer % 60);
                if (timer <= 0)
                {
                    GameEnder();
                }
                timerText.text = string.Format("{0:00}:{1:00}", seconds, miliseconds);
                yield return null;
            } while (timer > 0);

        }
       
    }
}
