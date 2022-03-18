using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public static bool paused = false;
    public static void WordSaid(string word)
    { 
        // if (word == "right")
        // {
        //     PlayerController.MoveRight();
        // }
        // else if(word =="left")
        // {
        //     PlayerController.MoveLeft();
        // }
        // else if(word =="up")
        // {
        //     PlayerController.MoveUp();
        // }
        // else if(word =="down")
        // {
        //     PlayerController.MoveDown();
        // }
        // else if(word == "stop")
        // {
        //     PlayerController.Stop();
        // }
        // else if(word=="start")
        // {
        //     SceneManager.LoadScene("Maze");
        // }
        // else if(word =="tutorial")
        // {
        //     SceneManager.LoadScene("Tutorial");
        // }
        // else if(word =="restart")
        // {
        //     PlayerController.Restart();
        // }
        // else if(word =="menu")
        // {
        //     PlayerController.Menu();
        // }
        // else if(word == "pause")
        // {      
        //     PlayerController.Pause();  
        //     paused = true;
        // }
        // else if(word == "resume" && paused == true)
        // {
        //     PlayerController.Resume();
        //     paused = false;
        // }

        switch (word)
        {
            case "left":
                PlayerController.MoveLeft();         
                break;
            case "right":
                PlayerController.MoveRight();
                break;
            case "up":
                PlayerController.MoveUp();
                break;
            case "down":
                PlayerController.MoveDown();
                break;  
            case "stop":
                PlayerController.Stop();
                break;
            case "start":
                SceneManager.LoadScene("Maze");
                break;
            case "tutorial":
                SceneManager.LoadScene("Tutorial");
                break;
            case "restart":
                PlayerController.Restart();
                break; 
            case "menu":
                PlayerController.Menu();
                break;
            case "pause":
                PlayerController.Pause();  
                paused = true;
                break;
            // case "resume" && paused == true:
            //     PlayerController.Resume();
            //     paused = false;
        }

        if(word == "resume" && paused == true)
        {
            PlayerController.Resume();
            paused = false;
        }
    }
}
