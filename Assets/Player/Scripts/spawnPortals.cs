using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPortals : MonoBehaviour
{
    private GameObject portalPrefab;
    private float spawnDistance;
    private List<GameObject> activePortals = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        portalPrefab = Resources.Load<GameObject>("playerPortal");
        spawnDistance = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPlayerPortal()
    {
        Vector3 direction = transform.forward;

        Vector3 pos = Vector3.zero;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, spawnDistance))
        {
            Vector3 point = hit.point;
            if(hit.distance > 2.5)
            {
                pos = new Vector3(point.x - (direction.x * 2.5f), transform.position.y + portalPrefab.transform.position.y - 2.1f, point.z - (direction.x * 2.5f));
            }       
        }
        else
        {
            pos = transform.position + new Vector3(direction.x * spawnDistance, portalPrefab.transform.position.y - 2.1f, direction.z * spawnDistance);
        }

        Quaternion rotation = transform.rotation;
        rotation = rotation * Quaternion.AngleAxis(90, Vector3.up);

        activePortals.Add(Instantiate(portalPrefab, pos, rotation));

        if(activePortals.Count > 2)
        {
            removePortal(activePortals[0]);
        }
        if(activePortals.Count == 2)
        {
            activePortals[0].GetComponent<PortalScript>().setDestination(activePortals[1].GetComponent<Transform>());
            activePortals[1].GetComponent<PortalScript>().setDestination(activePortals[0].GetComponent<Transform>());
        }
    }

    public void removePortal(GameObject portal)
    {
        activePortals.Remove(portal);
        Destroy(portal);
    }
}
