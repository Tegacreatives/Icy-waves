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
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI healthText;
    //private UIManager ui;

    void Awake()
    {
        indestructibleTimer = 0;
        health = 15;

    }
    void Start()
    {
        //ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        Cursor.lockState = CursorLockMode.Locked;
        scoreText = GameObject.Find("_Score").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("_Health").GetComponent<TextMeshProUGUI>();
        healthText.text = health.ToString();
    }

    void Update()
    {
        indestructibleTimer -= Time.deltaTime;
    }

    public void takeDamage(float damage = 1)
    {
        if(indestructibleTimer < 0)
        {
            health -= damage;
            healthText.text = health.ToString();
            if (health <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
    public void addScore( float _score = 10)
    {
        score += _score;
        scoreText.text = score.ToString();
    }

    public void setIndestructibleTimer(float timer = 15)
    {
        indestructibleTimer = timer;
    }
}
