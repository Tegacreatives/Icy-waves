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
    private static float freezeTimer;
    private Animator animator;

    [SerializeField]
    private GameObject freezeBox;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        playerManager = player.GetComponent<PlayerManager>();

        animator = gameObject.transform.GetComponent<Animator>();
        spawner = GameObject.Find("Spawners").GetComponent<EnemySpawner>();
        navAgent = GetComponent<NavMeshAgent>();
        if (freezeBox == null)
        {
            freezeBox = gameObject.transform.Find("FreezeBox").gameObject;
        }
        freezeBox.SetActive(false);

        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeTimer < 0)
        {
            navAgent.isStopped = false;
            freezeBox.SetActive(false);
            navAgent.destination = playerTransform.position;
            if (freezeBox.activeSelf == true)
            {
                freezeBox.SetActive(false);
            }
            animator.speed = 1;
        }
        else
        {
            navAgent.isStopped = true;
            if (freezeBox.activeSelf == false)
            {
                freezeBox.SetActive(true);
            }
            animator.speed = 0;
        }
        if (Vector3.Distance(playerTransform.position, transform.position) < 2)
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
            playerManager.addScore();
            spawner.removeEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    public static void setFreezeTimer(float timer = 5)
    {
        if (timer == 5)
        {
            freezeTimer = timer;
        }
        else
        {
            freezeTimer -= timer;
        }
    }
}
