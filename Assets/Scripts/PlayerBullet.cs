using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D MyRB;
    public float Timer = 0;

    void FixedUpdate()
    {
        if (Timer > 0)
        {
            Timer -= Time.fixedDeltaTime;
            MyRB.velocity = transform.right * 50f - new Vector3(GameManager.instance.MyDragon.DragonSpeed, 0);
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") 
        {
            Debug.Log(collision.gameObject.tag);
            gameObject.SetActive(false);
        }
    }
}
