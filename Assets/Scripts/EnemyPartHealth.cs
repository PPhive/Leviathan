using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartHealth : MonoBehaviour
{
    public float health;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Bullet") 
        {

            //Destroy(gameObject);
        }
    }
}
