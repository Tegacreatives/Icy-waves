using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List <Transform> spawnerLocations;
    public List<GameObject> enemyList = new List<GameObject>();

    public GameObject enemyPrefab;

    private float timer = 0;
    private float maxTime = 3f;

    public float wave = 1;
    public float numberOfEnemies;
    private float breakTime;
    private float growthPerWave;

    void Start()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("Spawner");

        foreach(GameObject obj in tempArray)
        {
            spawnerLocations.Add(obj.transform);
        }

        enemyPrefab = Resources.Load<GameObject>("Enemy");
        numberOfEnemies = 2;
        breakTime = 5;
        growthPerWave = numberOfEnemies / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfEnemies > 0)
        {
            if(timer < 0)
            {
                numberOfEnemies -= 1;

                Vector3 pos = spawnerLocations[Random.Range(0, spawnerLocations.Count)].position + new Vector3(0, 1, 0);

                enemyList.Add(Instantiate(enemyPrefab, pos, Quaternion.identity));

                timer = maxTime;
            }
        }
        else if(enemyList.Count == 0)
        {
            wave++;
            timer = breakTime;
            growthPerWave += (10 * wave);
            numberOfEnemies = 100 + (growthPerWave * wave);
        }
        timer -= Time.deltaTime;
    }

    public void removeEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }
}
