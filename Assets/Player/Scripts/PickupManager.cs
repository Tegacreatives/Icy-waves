using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private Shooting shot;
    private PlayerManager playerM;
     
    void Start()
    {
        shot = GetComponent<Shooting>();
        playerM = GetComponent<PlayerManager>();
    }

    void Update()
    {
        EnemyMovement.setFreezeTimer(Time.deltaTime);
    }

    public void setShootingTimer()
    {
        shot.setTrippleShooterTimer();
    }

    public void setFreezeTimer()
    {
        EnemyMovement.setFreezeTimer();
    }

    public void setIndestructibleTimer()
    {
        playerM.setIndestructibleTimer();
    }
}
