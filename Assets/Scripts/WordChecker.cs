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
        public GameObject gameOver;

        public GameObject scoreObject;
        public GameObject timeObject;
        public GameObject audio;
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
            PlayerPrefs.SetInt("score", 0);
            score = 0;
            gameOver.SetActive(false);
            /*
            yesButton.SetActive(false);
            noButton.SetActive(false);
            bgGameOver.SetActive(false);
            */
            audio.SetActive(true);
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
                currentTime = 0;
                PlayerPrefs.SetInt("score", score);
                gameOver.SetActive(true);
                audio.SetActive(false);
            }
            else if (referenceWord[referenceWord.Length - 1] == inputWord[0] //index: referenceWord.Length - 1
                && WordManager.wordList.Contains(inputWord))
            {
                WordManager.RemoveWord(inputWord); //remove the input word to avoid repetition
                referenceWord = inputWord; //makes the input word to be the reference word
                outputField.GetComponent<Text>().text = referenceWord;
                score += inputWord.Length;
                scoreObject.GetComponent<Text>().text = score.ToString();
                PlayerPrefs.SetInt("score", score);
            }
            else
            {
                /*
                gameOver.GetComponent<Text>().text = "GAME OVER\nWould You like to try again?";
                
                
                yesButton.SetActive(true);
                noButton.SetActive(true);
                bgGameOver.SetActive(true);
                
                SceneManager.LoadScene("GameOver");
                */
                PlayerPrefs.SetInt("score", score);
                currentTime = 0;
                gameOver.SetActive(true);
                audio.SetActive(false);
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
                
                SceneManager.LoadScene("GameOver");
                */
                PlayerPrefs.SetInt("score", score);
                currentTime = 0;
                gameOver.SetActive(true);
                audio.SetActive(false);
            }



        }





      
        
        
    }
}
