using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    public GameObject player;
    public GameObject mapDetails;
    TextMeshPro[] textMeshPros;
    public TextMeshProUGUI waveText;
    private float enemyInterval = 3f;
    // list with transform positions
    private List<Vector3> m_SpawnPoints = new List<Vector3>();
    private int indexSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        // fill m_SpawnPoints with random transform.positions
        StartCoroutine(spawnEnemy(enemyInterval, enemy));

        // play map details animation
        mapDetails.GetComponent<Animator>().Play("MapDetailsFadeOut");
        
        // get all textmeshpro components from mapDetails
        textMeshPros = mapDetails.GetComponentsInChildren<TextMeshPro>();

        // add xyz (1,1,1) to m_SpawnPoints
        m_SpawnPoints.Add(new Vector3(280.0f, 1.75f, -195.0f));

        StartCoroutine(Wave());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // coroutine wave
    private IEnumerator Wave()
    {
        // instantiate enemy at random position
        Vector3 spawnPoint = m_SpawnPoints[indexSpawn];
        
        Instantiate(enemy, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z - 5), Quaternion.identity);
        Instantiate(enemy, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z + 5), Quaternion.identity);
        Instantiate(enemy, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), Quaternion.identity);
        Instantiate(enemy, new Vector3(spawnPoint.x - 5, spawnPoint.y, spawnPoint.z), Quaternion.identity);
        Instantiate(enemy, new Vector3(spawnPoint.x + 5, spawnPoint.y, spawnPoint.z), Quaternion.identity);
        
        indexSpawn = (indexSpawn + 1) % m_SpawnPoints.Count;

        // wait 3 seconds
        yield return new WaitForSeconds(10);

        // if count of enemies is bigger than 20
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 20)
        {
            // wait 3 seconds
            yield return new WaitForSeconds(3);
            StartCoroutine(Wave());
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 10f), 1.7f, Random.Range(-10f, 10f)), Quaternion.identity);
        newEnemy.transform.LookAt(player.transform);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
