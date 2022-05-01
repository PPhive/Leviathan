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
            MyRB.velocity = transform.right * 100f - new Vector3(GameManager.instance.MyDragon.DragonSpeed, 0);
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }
}
