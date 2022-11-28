using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    public GameObject player;

    private float enemyInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // fill m_SpawnPoints with random transform.positions 
        StartCoroutine(spawnEnemy(enemyInterval, enemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 10f), 1.7f, Random.Range(-10f, 10f)), Quaternion.identity);
        newEnemy.transform.LookAt(player.transform);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
