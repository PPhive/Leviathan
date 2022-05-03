using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float timer;
    private GameObject Bullet;
    [SerializeField]
    private Rigidbody2D MyRB;
    void Start()
    {
        MyRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.fixedDeltaTime;
            MyRB.velocity = transform.right * 10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
