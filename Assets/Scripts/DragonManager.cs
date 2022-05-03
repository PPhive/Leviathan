using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour
{
    public GameObject Head, Tail;
    public List<GameObject> Body;
    public List<int[]> Level = new List<int[]>();
    
    [Space(10)]
    [SerializeField]
    private List<GameObject> Segments;
    [SerializeField]
    private float GraphShift, SegLength;
    public float DragonSpeed;
    public float DragonPos;
    public float SinBigAmp, SinBigFreq, SinSmallAmp, SinSmallFreq;
    public int DragonLength;

    void Start()
    {
        Level.Add(new int[4] { 0, 2, 1, 3 });
        SpawnDragon(DragonLength);
    }

    void FixedUpdate()
    {
        if (GameManager.instance.CurrentSate == GameManager.States.Game) 
        {
            GraphShift += DragonSpeed * Time.fixedDeltaTime;
            SegmentsFollowCurveStatic1();
        }
    }


    void SegmentsFollowCurveStatic1() //Y = Sin(0.03x) + Sin(0.2x)
    {
        for (int i = Segments.Count - 1; i >= 0; i--)
        {
            float XPos = 0 - SegLength * i;
            float XminusGraphShift = Segments[i].transform.position.x + GraphShift;
            //DragonSegment's Height is controlled by    y = f(x)
            Segments[i].transform.position = new Vector3(XPos, SinBigAmp * Mathf.Sin(SinBigFreq * XminusGraphShift) + SinSmallAmp * Mathf.Sin(SinSmallFreq * XminusGraphShift), 0.1f * i);
            
            //DragonSegment's Angle is controlled by     dy = f'(x)dx
            float DY = SinBigAmp * SinBigFreq * Mathf.Cos(SinBigFreq * XminusGraphShift) + SinSmallAmp * SinSmallFreq * Mathf.Cos(SinSmallFreq * XminusGraphShift);
            Segments[i].transform.eulerAngles = transform.forward * Mathf.Atan(DY) / 3.14f * 180f;
        }
    }

    void SpawnDragon(int Length) 
    {
        if (Length > 3)
        {
            int PatternCounter = 0;
            for (int i = 0; i < Length; i++) //Spawn head
            {
                if (i == 0)
                {
                    GameObject NewSeg = Instantiate(Head);
                    Segments.Add(NewSeg);
                }
                else if (i == Length - 1) //Spawn tail
                {
                    GameObject NewSeg = Instantiate(Tail);
                    Segments.Add(NewSeg);
                }
                else //Spawn body
                {
                    GameObject NewSeg = Instantiate(Body[Level[GameManager.instance.Level][PatternCounter]]);
                    Segments.Add(NewSeg);
                    PatternCounter++;
                    if (PatternCounter >= Level[GameManager.instance.Level].Length)
                    {
                        PatternCounter = 0;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Dragon too short, can't spawn");
        }
    }
}
