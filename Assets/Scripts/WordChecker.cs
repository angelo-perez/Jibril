using ForSinglePlayer;
using UnityEngine;
using UnityEngine.UI;

namespace WordCheck
{
    public class WordChecker : MonoBehaviour
    {
        public string inputWord;
        public string referenceWord;
        public int score;
        public float currentTime;
        public float startingTime;
        public GameObject inputField;
        public GameObject outputField;
        public GameObject gameOver;
        public GameObject scoreObject;
        public GameObject timeObject;
        
        void Start()
        {
            referenceWord = WordManager.GetRandomWord(); // gets random word
            outputField.GetComponent<Text>().text = referenceWord;
            WordManager.RemoveWord(referenceWord);
            currentTime = startingTime;
        }

        public void StoreWord()
        {
            inputWord = (inputField.GetComponent<Text>().text).ToLower(); // add ToLower later 
            currentTime = startingTime;
        }
        public void CheckWord()
        {
            if (referenceWord[referenceWord.Length - 1] == inputWord[0] //index: referenceWord.Length - 1
                && WordManager.wordList.Contains(inputWord))
            {
                WordManager.RemoveWord(inputWord); //remove the input word to avoid repetition
                referenceWord = inputWord; //makes the input word to be the reference word
                outputField.GetComponent<Text>().text = referenceWord;
                score += 5;
                scoreObject.GetComponent<Text>().text = score.ToString();
            }
            else
            {
                gameOver.GetComponent<Text>().text = "GAME OVER";
                currentTime = 0;
            }
        }

        void Update() //for time
        {
            currentTime -= 1 * Time.deltaTime;
            timeObject.GetComponent<Text>().text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                gameOver.GetComponent<Text>().text = "GAME OVER";
            }
        }




      
        
        
    }
}