using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private float health;
    private float score = 0;
    private TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GameObject.Find("_Score").GetComponent<TextMeshProUGUI>();
        health = 15;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void takeDamage(float damage = 1)
    {
        health -= damage;
        if(health <= 0)
        {
            Time.timeScale = 0;
        }
    }
    public void addScore( float _score = 10)
    {
        score += _score;
        scoreText.text = score.ToString();
    }
}
