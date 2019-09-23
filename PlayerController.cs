
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    public Text playerLives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        SetLivesText();
        playerLives.text= "3";
    }

    void FixedUpdate()

    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            other.gameObject.SetActive(false);
            SetLivesText();
            lives = lives - 1;

            playerLives.text = "Lives: " +lives.ToString();
            if (lives < 1)
            {
                SetLivesText();
                winText.text = "You lose!";
                gameObject.SetActive(false);
            }
        }

        if (count == 8)
        {
            transform.position = new Vector2(-103.82f, 25.34f);
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 16)
        { winText.text = "You win! Game created by Luke Fender!"; }
    }
    void SetLivesText()
    {
        playerLives.text = "Lives: " + lives.ToString();
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}