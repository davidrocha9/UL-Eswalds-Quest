using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;
    public float fireBallSpeed = 600;
    private float distance = 100.0f;
    public void FireBallAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, distance * ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                FireBallAttack();
            }
        }
    }
}
