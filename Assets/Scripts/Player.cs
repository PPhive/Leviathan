using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private GameObject Rudder;

    [SerializeField]
    private float Speed, PitchAngleAccel, PitchAngle, PitchMomentum, RealPitchAngle;

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
            PitchAngle = Mathf.Clamp(PitchAngle += PitchAngleAccel * Time.fixedDeltaTime, -80f, 80f);
        }
        else if (MyInput.PitchVector < 0)
        {
            PitchAngle = Mathf.Clamp(PitchAngle -= PitchAngleAccel * Time.fixedDeltaTime, -80f, 80f);
        }
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

        RealPitchAngle = PitchMomentum + PitchAngle;

        //Updown Temp
        transform.position += new Vector3(0, Mathf.Sin(RealPitchAngle / 180f * 3.1415f) * Speed * Time.fixedDeltaTime,0);
        transform.position += new Vector3(0, Mathf.Sin(RealPitchAngle / 180f * 3.1415f) * Speed * Time.fixedDeltaTime, 0);
    }
}
