using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField]
    private float mode;
    private AudioSource audio;
    private PickupManager puManager;
    // Start is called before the first frame update
    void Start()
    {
        string name = gameObject.transform.parent.name;
        audio = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
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
            audio.Play();
            gameObject.SetActive(false);
            Destroy(transform.parent, 1f);
        }
    }
}
