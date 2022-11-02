using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupGenerator : MonoBehaviour
{
    private List<GameObject> pickupPrefabs = new List<GameObject>();
    private Collider floor;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.Find("Floor").GetComponent<Collider>();
        pickupPrefabs.Add(Resources.Load<GameObject>("FreezePickup"));
        pickupPrefabs.Add(Resources.Load<GameObject>("IndestructiblePickup"));
        pickupPrefabs.Add(Resources.Load<GameObject>("ShootingPickup"));
    }

    void FixedUpdate()
    {
        int odds = Random.Range(0, 200);
        if(odds == 0)
        {
            spawnPickup();
        }
    }

    private void spawnPickup()
    {
        Vector3 pos = Vector3.zero;
        float scaleX = pickupPrefabs[0].transform.localScale.x;
        Vector3 scale = new Vector3(scaleX, scaleX, scaleX);
        int index = 0;
        do
        {
            float xAxis = Random.Range(floor.bounds.min.x, floor.bounds.max.x);
            float zAxis = Random.Range(floor.bounds.min.z, floor.bounds.max.z);
            pos = new Vector3(xAxis, floor.bounds.max.y + 1, zAxis);
            index++;
        }
        while (Physics.CheckBox(pos, scale) && index > 10);
        
        Instantiate(pickupPrefabs[Random.Range(0,pickupPrefabs.Count)], pos, Quaternion.identity);
    }
}
