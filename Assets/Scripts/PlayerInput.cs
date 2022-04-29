using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //This code processes the player's inputs into multipliers for player control to process
    public float SpeedVector;
    public float PitchVector;

    void Update()
    {
        SpeedVector = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SpeedVector += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SpeedVector -= 1;
        }

        PitchVector = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PitchVector += 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PitchVector -= 1;
        }
    }
}
