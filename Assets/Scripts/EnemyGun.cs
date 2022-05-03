using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    private GameObject MyBullet;
    [SerializeField]
    private float CDTimer, CD, Range, AngleMin, AngleMax;//(Rate of fire) (Fire Range) (MinFireAngle) (MaxFireAngle)
    [SerializeField]
    private float TurnSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float PlayerDistanceX = GameManager.instance.MyPlayer.transform.position.x - transform.position.x;
        float PlayerDistanceY = GameManager.instance.MyPlayer.transform.position.y - transform.position.y;
        float PlayerAngle = Mathf.Atan2(PlayerDistanceY, PlayerDistanceX) / 3.1415f * 180f;
        if (PlayerAngle < 0)
        {
            PlayerAngle += 360;
        }

        if (transform.eulerAngles.z < PlayerAngle)
        {
            transform.eulerAngles = transform.forward * Mathf.Clamp(transform.eulerAngles.z + TurnSpeed * Time.deltaTime, AngleMin, Mathf.Min(PlayerAngle, AngleMax));
        }
        else if (transform.eulerAngles.z > PlayerAngle)
        {
            transform.eulerAngles = transform.forward * Mathf.Clamp(transform.eulerAngles.z - TurnSpeed * Time.deltaTime, Mathf.Max(PlayerAngle, AngleMin), AngleMax);
        }

        if (CDTimer > CD)
        {
            float DistanceToPlayer = Vector2.Distance(GameManager.instance.MyPlayer.transform.position, transform.position);
            if (PlayerAngle >= AngleMin && PlayerAngle <= AngleMax && DistanceToPlayer < Range) //If player is within the set Angle and range
            {
                Fire(transform.position, transform.eulerAngles.z);
                Fire(transform.position, transform.eulerAngles.z);
                Fire(transform.position, transform.eulerAngles.z);
            }
        }
        else
        {
            CDTimer += Time.deltaTime;
        }
    }

    private void LookTowardsPlayer() 
    {
        
    }

    private void Fire(Vector3 Position, float Angle)
    {
        GameObject ThisBullet = Instantiate(MyBullet);
        ThisBullet.transform.eulerAngles = new Vector3(0,0,Angle + Random.Range(-10f,10f));
        ThisBullet.transform.position = Position + ThisBullet.transform.right * 2f;
        CDTimer = 0;
    }
}
