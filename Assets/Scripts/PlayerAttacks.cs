using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;
    public GameObject currentWeapon;
    public float fireBallSpeed = 600;
    private float distance = 100.0f;
    private bool thrown = false;
    public TextMeshProUGUI bombCnt;
    // list with all weapons
    public List<Sprite> weapons = new List<Sprite>();
    int weaponIndex = 0;
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;
    
    // start function
    void Start()
    {
    }
    
    public void FireBallAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        // make ball rotation same as player
        ball.transform.rotation = transform.rotation;
        //ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }

    public void SwitchWeapon()
    {
        weaponIndex = (weaponIndex + 1) % weapons.Count;
        // change current Weapon sprite
        currentWeapon.GetComponent<Image>().sprite = weapons[weaponIndex];
    }

    public void SwordAttack()
    {
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchWeapon();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            Debug.DrawRay(ray.origin, distance * ray.direction, Color.red);

            switch(weaponIndex)
            {
                case 0:
                    if (CanAttack)
                    {
                        SwordAttack();
                    }
                    break;
                case 1:
                    if (int.Parse(bombCnt.text) > 0)
                    {
                        FireBallAttack();
                        
                        // change bombCnt to the value it had minus 1
                        bombCnt.text = (int.Parse(bombCnt.text) - 1).ToString();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
