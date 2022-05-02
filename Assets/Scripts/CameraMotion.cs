using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField]
    private Camera MyCamera;
    [SerializeField]
    private GameObject Edges;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = GameManager.instance.MyPlayer.transform.position;

        float PosYClamped = Mathf.Clamp(PlayerPos.y * 0.5f, -20, 20);

        transform.position = new Vector3(PlayerPos.x, PosYClamped, transform.position.z);
        MyCamera.orthographicSize = Mathf.Clamp(Mathf.Abs(PlayerPos.y) * 0.5f + 7f, 0 , 15);
        Edges.transform.localScale = new Vector3(MyCamera.orthographicSize, MyCamera.orthographicSize,0);
    }
}
