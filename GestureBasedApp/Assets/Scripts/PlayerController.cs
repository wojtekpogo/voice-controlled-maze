using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static float speed = 1f; 
    public static Rigidbody2D rb;
    public static Vector2 velocity;
    [SerializeField] private GameObject loseMenu;
    

    public static GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
            instance = this.gameObject;
            Time.timeScale = 1f;
            rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //instance.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*speed,Input.GetAxis("Vertical")*speed);

    }

     public static void MoveRight()
     {
         rb.velocity = new Vector2(speed, 0);
     }

    public static void MoveLeft()
    {
        rb.velocity = new Vector2(speed * -1, 0);

        //rb.MovePosition(rb.position + velocity *Time.deltaTime);
    }

     public static void MoveUp()
    {
        rb.velocity = new Vector2(0,speed);
    }

     public static void MoveDown()
    {
        rb.velocity = new Vector2(0,speed * -1);
    }

    public static void Stop()
    {
        rb.velocity = new Vector2(0,0);
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("Paused");
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        Debug.Log("Resumed");
    }

    public static void Restart()
    {
        //loseMenu.SetActive(false);
        Debug.Log("restarted");
        SceneManager.LoadScene("Maze");
    }

    public static void Menu()
    {
        //loseMenu.SetActive(false);
        Debug.Log("menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
       loseMenu.SetActive(true);
       Time.timeScale = 0f;
    }



}
