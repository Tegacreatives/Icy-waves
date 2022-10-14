using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public static float timer = 0;
    private Vector3 startingScale;
    private Vector3 multiplierScale;
    private bool used = false;
    private Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        multiplierScale = new Vector3(startingScale.x / 20, startingScale.y / 20, startingScale.z / 20);
    }

    void OnEnable()
    {
        if(transform.localScale != Vector3.zero)
        {
            startingScale = transform.localScale;
        }
        transform.localScale = Vector3.zero;
        used = false;
    }

    void FixedUpdate()
    {
        if (used)
        {
            if(transform.localScale.x > 0.005f)
            {
                transform.localScale = new Vector3(
                    Mathf.Abs(transform.localScale.x - multiplierScale.x),
                    Mathf.Abs(transform.localScale.y - multiplierScale.y),
                    Mathf.Abs(transform.localScale.z - multiplierScale.z)
                    );
            }
            else if (gameObject.tag == "Portal")
            {
                transform.parent.GetComponent<PortalManager>().spawnPortals();
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<spawnPortals>().removePortal(gameObject);

            }
        }
        else if(transform.localScale.x < startingScale.x)
        {
            transform.localScale = new Vector3(
                    transform.localScale.x + multiplierScale.x,
                    transform.localScale.y + multiplierScale.y,
                    transform.localScale.z + multiplierScale.z
                    );
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && timer < 0)
        {
            timer = 5;
            if(destination == null)
            {
                return;
            }
            StartCoroutine(setUsed());
            StartCoroutine(destination.gameObject.GetComponent<PortalScript>().setUsed());

            col.gameObject.transform.position = new Vector3(destination.position.x, col.gameObject.transform.position.y, destination.position.z);  
        }
    }

    public void setDestination(Transform dest)
    {
        destination = dest;
    }
    public IEnumerator setUsed()
    {
        yield return new WaitForSeconds(1);
        used = !used;
    }
}
