using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject health;
    public GameObject player;

    private float healthInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // fill m_SpawnPoints with random transform.positions
        StartCoroutine(spawnHealth(healthInterval, health));
    }

    private IEnumerator spawnHealth(float interval, GameObject health)
    {
        yield return new WaitForSeconds(interval);
        GameObject newhealth = Instantiate(health, new Vector3(Random.Range(-10f, 10f), 0.9f, Random.Range(-10f, 10f)), Quaternion.identity);
        StartCoroutine(spawnHealth(interval, health));
    }
}
