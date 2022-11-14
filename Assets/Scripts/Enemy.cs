using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void Chase()
    {
        // rotate on y axis to face player without rotating on x and z axis
        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        Debug.Log(Vector3.Distance(transform.position, player.transform.position));

        // if distance between player and enemy is greater than 1 and doesnt collide with other enemies with spherecast, move towards player
        if (Vector3.Distance(transform.position, player.transform.position) > 1 && !Physics.Raycast(transform.position, transform.forward, 1))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    // ignore collision with player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("colisao");
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
