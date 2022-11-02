using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField]
    private float mode;
    private PickupManager puManager;
    // Start is called before the first frame update
    void Start()
    {
        string name = gameObject.transform.parent.name;
        //switch (name)
        //{
        //    case "ShootingPickup":
        //        mode = 1;
        //        break;

        //    case "FreezePickup":
        //        mode = 2;
        //        break;

        //    case "IndestructiblePickup":
        //        mode = 3;
        //        break;
        //    default:
        //        print("Mode not set, invalid name");
        //        break;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            puManager = col.gameObject.GetComponent<PickupManager>();
            switch (mode)
            {
                case 1:
                    puManager.setShootingTimer();
                    break;
                case 2:
                    puManager.setFreezeTimer();
                    break;
                case 3:
                    puManager.setIndestructibleTimer();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
