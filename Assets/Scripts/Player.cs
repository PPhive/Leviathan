using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private GameObject Rudder;

    [SerializeField]
    private float Speed,PitchSpeedCap, PitchAngleAccel, PitchAngle, PitchSpeed, RealPitchAngle;

    [SerializeField]
    private float Momentum;

    [SerializeField]
    private PlayerInput MyInput;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(0,0, RealPitchAngle);
    }

    void FixedUpdate()
    {
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
        /*
        else 
        {
            if (PitchAngle > 0) 
            {
                PitchAngle = Mathf.Clamp(PitchAngle -= PitchAngleAccel * Time.fixedDeltaTime, 0, 80f);
            }
            if (PitchAngle < 0)
            {
                PitchAngle = Mathf.Clamp(PitchAngle += PitchAngleAccel * Time.fixedDeltaTime, -80f, 0);
            }
        }
        */

        PitchAngle += PitchSpeed * Time.fixedDeltaTime;

        /*
        if (PitchAngle > 360)
        {
            PitchAngle -= 360;
        }
        if (PitchAngle < 0)
        {
            PitchAngle += 360;
        }
        */

        RealPitchAngle = PitchAngle;

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
}
