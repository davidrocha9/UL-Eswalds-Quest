using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBehavior : MonoBehaviour
{

    public Text textBox;
    public Slider healthBar;
    private bool tookDmg = false;
    private bool healed = false;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon")
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            if(GameManager.gameManager._playerHealth.Health == 0 || GameManager.gameManager._playerHealth.Health < 0  ) {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }else if(other.tag == "HealthItem") {
            PlayerHeal(30);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    void Update()
    {
        textBox.text = "Health: " + GameManager.gameManager._playerHealth.Health;
    }

    void FixedUpdate()
    {
        if (tookDmg)
        {
            healthBar.value = healthBar.value - 0.01f;
            Debug.Log(healthBar.value);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            if (healthBar.value * 100.0f <= GameManager.gameManager._playerHealth.Health)
            {
                tookDmg = false;
            }
        }


        if(healed) {
            healthBar.value = healthBar.value + 0.01f;
            Debug.Log(healthBar.value);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            if (healthBar.value * 100.0f >= GameManager.gameManager._playerHealth.Health)
            {
                healed = false;
            }
        }
    }

    // Methods

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        Debug.Log(GameManager.gameManager._playerHealth.Health);
        tookDmg = true;
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        healed = true;
    }
}
