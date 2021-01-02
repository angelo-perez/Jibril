using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ForSinglePlayer
{
    public static class WordManager
    {
        public static List<string> wordList; //declaration of a variable
        public static List<string> ReadTextFile()
        {
            wordList = File.ReadAllLines("EnglishWords84095.txt").ToList(); //reads and create list of words based on the items in text file
                
            return wordList; 
        }
            
        public static string GetRandomWord()
        {
            var random = new Random(); //making intance to be able to used certain methods of it
            var _words = ReadTextFile(); //calls the ReadTextFile method
            int index = random.Next(_words.Count); //generates a random number based on the item's count in the list
            string randomWord = _words[index]; //uses the random number as index to produce a random word from the word list

            return randomWord;
    
        }
        public static void RemoveWord(string removeWord)
        {
            wordList.Remove(removeWord); //removes a word from the list
        }

    }
}