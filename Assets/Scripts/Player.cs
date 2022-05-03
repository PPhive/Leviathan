using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float Health = 3;
    [SerializeField]
    private GameObject MySprite;
    [SerializeField]
    private Rigidbody2D MyRigidbody;

    [SerializeField]
    [Header("Pitch")]
    private float RealPitchAngle;
    [SerializeField]
    private float PitchAngleAccel, PitchAngle, PitchSpeed, PitchSpeedCap;

    [Space(10)]

    [SerializeField]
    [Header("Speed")]
    private float Speed;
    [SerializeField]
    private float EngineSpeed, EngineAccel, EngineMaxSpeed, EngineMinSpeed, EngineOverDriveSpeed;

    [Space(10)]

    [SerializeField]
    private float Momentum;

    [SerializeField]
    private PlayerInput MyInput;

    [SerializeField]
    private PlayerBulletSpawner MyBulletSpawner;
    private float BulletFireCD;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(0,0, RealPitchAngle);
    }

    void FixedUpdate()
    {
        if (GameManager.instance.CurrentState == GameManager.States.Game)
        {
            //Pitch Control
            if (MyInput.PitchVector > 0)
            {
                AdjustPitchSpeed(PitchSpeedCap);
            }
            else if (MyInput.PitchVector < 0)
            {
                AdjustPitchSpeed(-PitchSpeedCap);
            }
            else
            {
                AdjustPitchSpeed(0);
            }

            PitchAngle += PitchSpeed * Time.fixedDeltaTime;
            RealPitchAngle = PitchAngle;

            //Speed Control
            if (MyInput.SpeedVector > 0)
            {
                AdjustEngineSpeed(EngineOverDriveSpeed);
            }
            if (MyInput.SpeedVector < 0)
            {
                AdjustEngineSpeed(EngineMinSpeed);
            }
            else
            {
                if (MyInput.SpeedVector == 0 && EngineSpeed > EngineMaxSpeed)
                {
                    AdjustEngineSpeed(EngineMaxSpeed);
                }
            }
            Speed = EngineSpeed;


            if (BulletFireCD <= 0)
            {
                if (MyInput.Fire)
                {
                    MyBulletSpawner.Fire();
                }
                BulletFireCD += 0.1f;
            }
            else
            {
                BulletFireCD -= Time.fixedDeltaTime;
            }

            float VerticalSpeed = Mathf.Sin(RealPitchAngle / 180f * 3.1415f) * Speed;
            float HorizontalSpeed = Mathf.Cos(RealPitchAngle / 180f * 3.1415f) * Speed - GameManager.instance.MyDragon.DragonSpeed;
            MyRigidbody.velocity = new Vector2(HorizontalSpeed, VerticalSpeed);
            GameManager.instance.MyPlayerVelocity = MyRigidbody.velocity + new Vector2(GameManager.instance.MyDragon.DragonSpeed, 0);
        }
        else if (GameManager.instance.CurrentState == GameManager.States.Menu)
        {
            GameManager.instance.MyPlayerVelocity = transform.right * 15;
        }
    }

    void AdjustPitchSpeed(float TargetSpeed) 
    {
        if (PitchSpeed > TargetSpeed)
        {
            PitchSpeed = Mathf.Clamp(PitchSpeed -= PitchAngleAccel * Time.fixedDeltaTime, TargetSpeed, 30f);
        }
        else if (PitchSpeed < TargetSpeed)
        {
            PitchSpeed = Mathf.Clamp(PitchSpeed += PitchAngleAccel * Time.fixedDeltaTime, -30f, TargetSpeed);
        }
    }

    void AdjustEngineSpeed(float TargetSpeed) 
    {
        if (EngineSpeed > TargetSpeed)
        {
            EngineSpeed = Mathf.Clamp(EngineSpeed -= EngineAccel * Time.fixedDeltaTime, TargetSpeed, 9999f);
        }
        else if (EngineSpeed < TargetSpeed)
        {
            EngineSpeed = Mathf.Clamp(EngineSpeed += EngineAccel * Time.fixedDeltaTime, 0, TargetSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.MyCameraMotion.Shake();
            Health -= 1;
        }

        if (Health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    public void Ready() 
    {
        transform.position = new Vector2(0, 15);
        Health = 5;
        MySprite.SetActive(true);
    }

    public void Death() 
    {
        MySprite.SetActive(false);
    }
}
