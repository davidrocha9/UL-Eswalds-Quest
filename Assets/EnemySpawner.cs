using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private float enemyInterval = 5f;

    public Transform[] m_SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemy));

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length - 1));
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, m_SpawnPoints[randomNumber].transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));



    }
}
