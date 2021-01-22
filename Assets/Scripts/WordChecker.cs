using ForSinglePlayer;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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


        public GameObject scoreObject;
        public GameObject timeObject;
        public InputField input; 

        void Awake()
        {
            input = GameObject.Find("inputField").GetComponent<InputField>();
        }


        void Start()
        {
            referenceWord = WordManager.GetRandomWord(); // gets random word
            outputField.GetComponent<Text>().text = referenceWord;
            WordManager.RemoveWord(referenceWord);
            currentTime = startingTime;
            score = 0;

            /*
            yesButton.SetActive(false);
            noButton.SetActive(false);
            bgGameOver.SetActive(false);
            */
        }

        public void StoreWord()
        {
            inputWord = (inputField.GetComponent<Text>().text).ToLower(); // add ToLower later 
            input.text = "";
            currentTime = startingTime;
        }
        public void CheckWord()
        {
            if (inputWord == "")
            {
                gameOver.GetComponent<Text>().text = "GAME OVER\nWould You like to try again?";

                currentTime = 0;
                yesButton.SetActive(true);
                noButton.SetActive(true);
                bgGameOver.SetActive(true);
            }
            else if (referenceWord[referenceWord.Length - 1] == inputWord[0] //index: referenceWord.Length - 1
                && WordManager.wordList.Contains(inputWord))
            {
                WordManager.RemoveWord(inputWord); //remove the input word to avoid repetition
                referenceWord = inputWord; //makes the input word to be the reference word
                outputField.GetComponent<Text>().text = referenceWord;
                score += inputWord.Length;
                scoreObject.GetComponent<Text>().text = score.ToString();
            }
            else
            {
                /*
                gameOver.GetComponent<Text>().text = "GAME OVER\nWould You like to try again?";
                
                currentTime = 0;
                yesButton.SetActive(true);
                noButton.SetActive(true);
                bgGameOver.SetActive(true);
                */
                
                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene("GameOver");
            }
        }

        void Update() //for time
        {
            currentTime -= 1 * Time.deltaTime;
            timeObject.GetComponent<Text>().text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                /*
                currentTime = 0;
                gameOver.GetComponent<Text>().text = "GAME OVER\nWould You like to try again?";
                yesButton.SetActive(true);
                noButton.SetActive(true);
                bgGameOver.SetActive(true);
                */
                
                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene("GameOver");
                
            }



        }





      
        
        
    }
}