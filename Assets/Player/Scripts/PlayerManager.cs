using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage = 1)
    {
        health -= damage;
        print(health);
        if(health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
