using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;
    private GameObject player;
    private GameObject enemy;
    private bool hitOtherEnemy = false;
    public Slider sliderUI;
    public Slider BossSlider;


    private bool tookDmg;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        BossSlider = GameObject.Find("UI").GetComponent<Slider>();
        GameManager.gameManager._enemyHealth.SetHealth(data.hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.gameManager._enemyHealth.Health == 0 || GameManager.gameManager._enemyHealth.Health < 0) {
            Destroy(gameObject);
            BossSlider.gameObject.SetActive(false);
        }
        if (other.tag == "FireBall")
        {
                EnemyTakeDmg(30);
                if(GameManager.gameManager._enemyHealth.Health == 0 || GameManager.gameManager._enemyHealth.Health < 0) {
                    Destroy(this.gameObject);
                    BossSlider.gameObject.SetActive(false);
                }
                Debug.Log(GameManager.gameManager._enemyHealth.Health);

        }
        else if (other.tag == "Sword")
        {
                EnemyTakeDmg(40);
                if(GameManager.gameManager._enemyHealth.Health == 0 || GameManager.gameManager._enemyHealth.Health < 0) {
                    Destroy(this.gameObject);
                    BossSlider.gameObject.SetActive(false);
                }

        }
    }


    void FixedUpdate()
    {
        if (tookDmg)
        {
            if(data.boss) {
                BossSlider.value = BossSlider.value - 0.01f;
                Debug.Log(BossSlider.value);
                Debug.Log(GameManager.gameManager._enemyHealth.Health);
                if (BossSlider.value * 100.0f <= GameManager.gameManager._enemyHealth.Health)
                {
                    tookDmg = false;
                }
            } else {
                sliderUI.value = sliderUI.value - 0.01f;
                Debug.Log(sliderUI.value);
                Debug.Log(GameManager.gameManager._enemyHealth.Health);
                if (sliderUI.value * 100.0f <= GameManager.gameManager._enemyHealth.Health)
                {
                    tookDmg = false;
                }
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
        tookDmg = true;
    }

}
