using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private float health;
    private float score = 0;
    private float indestructibleTimer;
    private UIManager ui;
    private AnimationHandler anim;
    private GameObject mainMenu;

    [SerializeField]
    private GameObject indestructibleShield;

    private GameObject iceCube;
    private PostProcessing postProcessing;
    float highScore;
    void Awake()
    {
        indestructibleTimer = 0;
        health = 5;

    }
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        postProcessing = GameObject.Find("PostProcessing").GetComponent<PostProcessing>();
        if (indestructibleShield == null)
        {
            indestructibleShield = GameObject.Find("IndestructibleShield");
        }
        indestructibleShield.SetActive(false);
        anim = GetComponent<AnimationHandler>();
        ui.setHealthText(health.ToString());
        mainMenu = GameObject.Find("GameOverPanel");

        mainMenu.SetActive(false);
        highScore = PlayerPrefs.GetFloat("HighScore");

        if (PlayerPrefs.HasKey("HighScore"))
        {
            ui.setHighScore(highScore.ToString());
        }

    }

    void Update()
    {
        indestructibleTimer -= Time.deltaTime;
    }

    public void takeDamage(float damage = 1)
    {
        //Checks if the indestructible timer is less than zero and player's health is zero
        //Then plays the dead animation, set time scale to zero, opens the main menu and displays the cursor
        if (indestructibleTimer < 0)
        {
            health -= damage;
            ui.setHealthText(health.ToString());
            postProcessing.DamageTakeEffect();
            if (health <= 0)
            {
                anim.SetDead();
                Time.timeScale = 0;
                mainMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

            }
        }
        else if (indestructibleShield.activeSelf == true)
        {
            indestructibleShield.SetActive(false);
        }

    }

    public void addScore(float _score = 10)
    {
        score += _score;
        ui.setScoreText(score.ToString());

        if (PlayerPrefs.GetFloat("HighScore") > score)
        {
            ui.setHighScore(highScore.ToString());

        }
        else
        {
            ui.setHighScore(score.ToString());
            PlayerPrefs.SetFloat("HighScore", score);
        }

    }
    public void setIndestructibleTimer(float timer = 15)
    {
        indestructibleTimer = timer;
        indestructibleShield.SetActive(true);
    }

}
