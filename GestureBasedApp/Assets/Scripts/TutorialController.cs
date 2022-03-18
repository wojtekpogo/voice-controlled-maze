using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialController : MonoBehaviour
{
    public Text textComponent;
    public Text textToSay;
    public Text textToDisplay;
    public float delay = 0.1f; // delay between each letter appears
    public float wait = 0.6f;
    public string[] lines;
    public string[] wordLines;

    private int index =0;
    private int i =0;

    // array of rules
    string[] myWords = new string[] {"Go Left", " Move Right", "Go Up", "Go Down", "Resume The Game", "Pause The Game"};

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        //textToSay.text = myWords[i];
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }   
    }

    IEnumerator ShowText(){

        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text +=c;
            yield return new WaitForSeconds(delay);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(ShowText());
    }

    void NextLine()
    {
        if(index <lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(ShowText());
        }
    }

    IEnumerator NextWord(int i)
    {
        textToSay.color = Color.green;
        yield return new WaitForSeconds(wait);
        textToSay.color = Color.white;
        textToSay.text = myWords[i];
    }

    public void TextSaid(string word)
    {
        switch (word)
        {
            case "start":
                //i++;
                textComponent.text = "";
                StartCoroutine(NextWord(i));
                break;
            case "left":          
                i++;
                StartCoroutine(NextWord(i));
                break;
            case "right":
                i++;
                StartCoroutine(NextWord(i));
                break;
            case "up":
                i++;
                StartCoroutine(NextWord(i)); 
                break;
            case "down":
                //textToSay.color = Color.green;
                //SceneManager.LoadScene("Maze");
                i++;
                StartCoroutine(NextWord(i)); 
                break;  
            case "resume":
                i++;
                StartCoroutine(NextWord(i));
                break;
            case "pause":
                textToSay.color = Color.green;
                textToSay.text = "";
                textToDisplay.text = "Are you ready? Or you want to go back to menu.";
                break;
            case "ready":
                SceneManager.LoadScene("Maze");
                break;
            case "menu":
                SceneManager.LoadScene("Menu");
                break;       
        }
        
    }
}



