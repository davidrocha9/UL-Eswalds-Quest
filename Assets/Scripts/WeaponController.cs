using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(CanAttack)
            {
                SwordAttack();
            }
        }
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


}
