using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Rudder;

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
        //Pitch Control
        if (MyInput.PitchVector > 0)
        {
            AdjustPitchSpeed(PitchSpeedCap);
        }
        else if (MyInput.PitchVector < 0)
        {
            AdjustPitchSpeed(-PitchSpeedCap);
            //PitchAngle = PitchAngle -= PitchAngleAccel * Time.fixedDeltaTime;
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

        //Vertical Temp
        transform.position += new Vector3(0, Mathf.Sin(RealPitchAngle / 180f * 3.1415f) * Speed * Time.fixedDeltaTime,0);
        //Horizontal Temp
        transform.position += new Vector3((Mathf.Cos(RealPitchAngle / 180f * 3.1415f)  * Speed - GameManager.instance.MyDragon.DragonSpeed) * Time.fixedDeltaTime, 0, 0);
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
        Debug.Log(TargetSpeed);
    }
}
