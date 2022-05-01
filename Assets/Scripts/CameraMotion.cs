using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField]
    private Camera MyCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = GameManager.instance.MyPlayer.transform.position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y * 0.5f, transform.position.z);
        MyCamera.orthographicSize = PlayerPos.y * 0.3f + 7;
    }
}
