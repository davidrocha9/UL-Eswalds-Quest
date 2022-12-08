using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;
    public float fireBallSpeed = 600;
    private float distance = 100.0f;
    private bool thrown = false;
    public TextMeshProUGUI bombCnt;
    public void FireBallAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        // make ball rotation same as player
        ball.transform.rotation = transform.rotation;
        //ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, distance * ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {

            if (Input.GetKeyDown(KeyCode.F) && int.Parse(bombCnt.text) > 0)
            {
                FireBallAttack();

                // change bombCnt to the value it had minus 1
                bombCnt.text = (int.Parse(bombCnt.text) - 1).ToString();
            }
        }
    }
}
