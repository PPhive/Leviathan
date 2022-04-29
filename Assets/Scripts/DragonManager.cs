using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour
{
    [SerializeField]
    private List<SegmentScript> Segments;
    [SerializeField]
    private float GraphShift, SegLength;

    public float DragonSpeed; 


    void Start()
    {

    }

    void FixedUpdate()
    {
        GraphShift += DragonSpeed * Time.fixedDeltaTime; 
        SegmentsFollowCurve1();
    }


    void SegmentsFollowCurve1() 
    {
        for (int i = Segments.Count - 1; i >= 0; i--)
        {
            float XPos = 0 - SegLength * i;
            float XminusGraphShift = Segments[i].transform.position.x - GraphShift;
            Segments[i].transform.position = new Vector3(XPos, Mathf.Sin(0.2f * XminusGraphShift), 0);

            if (i > 0)
            {
                //This LookAt Segemnt of Code came from:
                //https://answers.unity.com/questions/585035/lookat-2d-equivalent-.html
                Vector3 dir = Segments[i - 1].transform.position - Segments[i].transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Segments[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}
