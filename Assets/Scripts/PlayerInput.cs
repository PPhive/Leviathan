using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //This code processes the player's inputs into multipliers for player control to process
    public float SpeedVector;
    public float PitchVector;
    public bool Fire;

    void Update()
    {
        SpeedVector = 0;
        if (Input.GetKey(KeyCode.W))
        {
            SpeedVector += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            SpeedVector -= 1;
        }

        PitchVector = 0;
        if (Input.GetKey(KeyCode.A))
        {
            PitchVector += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PitchVector -= 1;
        }

        if (Input.GetKey(KeyCode.J))
        {
            Fire = true;
        }
        else 
        {
            Fire = false;
        }
    }
}
