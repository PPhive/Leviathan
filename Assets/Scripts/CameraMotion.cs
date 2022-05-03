using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField]
    private Camera MyCamera;
    [SerializeField]
    private GameObject Edges;
    [SerializeField]
    private float ShakeTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = GameManager.instance.MyPlayer.transform.position;

        float PosYClamped = Mathf.Clamp(PlayerPos.y * 0.5f, -20, 20);

        transform.position = new Vector3(PlayerPos.x + 5, PosYClamped, transform.position.z);
        MyCamera.orthographicSize = Mathf.Clamp(Mathf.Abs(PlayerPos.y) * 0.2f + 10f, 0 , 15);
        Edges.transform.localScale = new Vector3(MyCamera.orthographicSize, MyCamera.orthographicSize,0);

        if (ShakeTimer > 0) 
        {
            ShakeTimer -= Time.deltaTime;
            MyCamera.gameObject.transform.localPosition = new Vector2(Mathf.Sin(ShakeTimer * 20 * 3.1415f) * ShakeTimer * 2,0);
        }

    }

    public void Shake() 
    {
        ShakeTimer = 0.25f;
    }
}
