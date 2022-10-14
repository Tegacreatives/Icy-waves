using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    private GameObject[] portals;
    private List <GameObject> activePortals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        portals = GameObject.FindGameObjectsWithTag("Portal");
        foreach(GameObject portal in portals)
        {
            portal.SetActive(false);
        }
        spawnPortals();
    }

    private void Update()
    {
        PortalScript.timer -= Time.deltaTime;
    }

    public void spawnPortals()
    {
        int portalIndex1 = Random.Range(0, portals.Length);
        int portalIndex2 = 0;
        do
        {
            portalIndex2 = Random.Range(0, portals.Length);
        } while (portalIndex1 == portalIndex2);

        while(activePortals.Count > 0)
        {
            activePortals[0].SetActive(false);
            activePortals.RemoveAt(0);
        }

        activePortals.Add(portals[portalIndex1]);
        activePortals.Add(portals[portalIndex2]);

        portals[portalIndex1].SetActive(true);
        portals[portalIndex2].SetActive(true);

        portals[portalIndex1].GetComponent<PortalScript>().setDestination(portals[portalIndex2].GetComponent<Transform>());
        portals[portalIndex2].GetComponent<PortalScript>().setDestination(portals[portalIndex1].GetComponent<Transform>());
    }
}
