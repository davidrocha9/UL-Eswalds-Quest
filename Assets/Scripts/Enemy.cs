using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;
    private GameObject player;
    private GameObject enemy;
    private bool hitOtherEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameManager.gameManager._enemyHealth.SetHealth(data.hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.gameManager._enemyHealth.Health == 0 || GameManager.gameManager._enemyHealth.Health < 0) {
            Destroy(gameObject);
        }
        if (other.tag == "FireBall")
        {
                EnemyTakeDmg(30);
                if(GameManager.gameManager._enemyHealth.Health == 0 || GameManager.gameManager._enemyHealth.Health < 0) {
                    Destroy(this.gameObject);
                }
                Debug.Log(GameManager.gameManager._enemyHealth.Health);
        }
        else if (other.tag == "Sword")
        {
                EnemyTakeDmg(40);
                if(GameManager.gameManager._enemyHealth.Health == 0 || GameManager.gameManager._enemyHealth.Health < 0) {
                    Destroy(this.gameObject);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hitOtherEnemy)
        {

        }

        Chase();
    }

    private void Chase()
    {
        // rotate on y axis to face player without rotating on x and z axis
        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        Debug.Log(Vector3.Distance(transform.position, player.transform.position));

        // if distance between player and enemy is greater than 1 and doesnt collide with other enemies with spherecast, move towards player
        if (Vector3.Distance(transform.position, player.transform.position) > 1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * data.speed);
        }
    }

    private void EnemyTakeDmg(int dmg)
    {
        GameManager.gameManager._enemyHealth.DmgUnit(dmg);
        Debug.Log(GameManager.gameManager._enemyHealth.Health);
    }

}
