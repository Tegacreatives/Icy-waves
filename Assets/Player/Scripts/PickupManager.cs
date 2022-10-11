using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private Shooting shot;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<Shooting>();
    }

    public void setShootingTimer()
    {
        shot.setTrippleShooterTimer();
    }
}
