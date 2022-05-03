using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartHealth : MonoBehaviour
{
    public float health;
    private float ShakeTimer;
    private Vector3 OriginalPos;
    void Start()
    {
        OriginalPos = transform.localPosition;
    }

    void Update()
    {
        if (ShakeTimer >= 0) 
        {
            transform.localPosition = OriginalPos + Vector3.right * Mathf.Sin(ShakeTimer * 40) * ShakeTimer * 0.5f;
            ShakeTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            health -= 1f;
            Shake();
            Instantiate(GameManager.instance.SmallBlood, transform.position - new Vector3(0, 0, 5), transform.rotation, transform.parent);
            collision.gameObject.SetActive(false);
        }
        if (health <= 0)
        {
            Instantiate(GameManager.instance.BigBlood, transform.position - new Vector3(0,0,5), transform.rotation, transform.parent);
            GameManager.instance.MyDragon.Health -= 1;
            Destroy(gameObject);
        }
    }

    void Shake() 
    {
        ShakeTimer = 0.25f;
    }
}
