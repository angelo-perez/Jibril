using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quotes : MonoBehaviour
{   
    public Text quoteText;

    void Start()
    {
        quotemod();
    }

    public void quotemod()
    {

        var random = new System.Random();
        var list = new List<string>{ 
             "\"Be mindful when it comes to your words. A string of some that don't mean much to you, may stick with someone else for a lifetime.\" -Rachel Wolchin",
            "\"Be careful with your words. Once they are said, they can be only forgiven, not forgotten.\" -Unknown",
            "\"Words are free. It's how you use them that may cost you.\" -KushandWizdom",
            "\"Raise your words, not your voice. It is rain that grows flowers, not thunder.\" -Rumi",
            "\"One kind word can change someone's entire day.\" -Unknown",
            "\"Kind words can be short and easy to speak, but their echoes are truly endless.\" -Mother Teresa",
            "\"The tongue has no bones, but is strong enough to break a heart. So be careful with your words.\" -Unknown",
            "\"Be careful what you say. You can say something hurtful in ten seconds, but ten years later, the wounds are still there.\" -Joel Osteen",
            "\"No matter what anybody tells you, words and ideas can change the world.\" -John Keating",
            "\"The best word shakers were the ones who understood the true power of words. They were the ones who could climb the highest.\" -Markus Zusak",
            "\"A broken bone can heal, but the wound a word opens can fester forever.\" -Jessamyn West",
            "\"Your words have power. Speak words that are kind, loving, positive, uplifting, encouraging, and life-giving.\" -Unknown"
            };
        int index = random.Next(list.Count);

        string wordInList = list[index];
        quoteText.GetComponent<Text>().text = wordInList;
    }
}
