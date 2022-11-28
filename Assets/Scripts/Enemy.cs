using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;
    private GameObject player;
    private GameObject enemy;

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
        }else if (other.tag == "Sword")
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
        Chase();
    }

    private void Chase()
    {
        //look at player
        transform.LookAt(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, data.speed * Time.deltaTime);

    }

    private void EnemyTakeDmg(int dmg)
    {
        GameManager.gameManager._enemyHealth.DmgUnit(dmg);
        Debug.Log(GameManager.gameManager._enemyHealth.Health);
    }

}
