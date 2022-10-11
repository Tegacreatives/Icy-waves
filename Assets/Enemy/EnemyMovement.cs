using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Transform playerTransform;
    private PlayerManager playerManager;
    private EnemySpawner spawner;
    private float health;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        playerManager = player.GetComponent<PlayerManager>();
        spawner = GameObject.Find("Spawners").GetComponent<EnemySpawner>();
        navAgent = GetComponent<NavMeshAgent>();
        health = 10;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        navAgent.destination = playerTransform.position;
        if(Vector3.Distance(playerTransform.position, transform.position) < 2)
        {
            playerManager.takeDamage();
            spawner.removeEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage = 10)
    {
        health -= damage;
        if (health <= 0)
        {
            spawner.removeEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}
