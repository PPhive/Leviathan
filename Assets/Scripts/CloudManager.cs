using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Clouds0;
    [SerializeField]
    private List<GameObject> Clouds1;
    [SerializeField]
    private List<GameObject> Clouds2;
    [SerializeField]
    private List<GameObject> Clouds3;
    [SerializeField]
    private List<GameObject> Clouds4;

    void Start()
    {
        
    }

    void Update()
    {
        MoveCloud(Clouds4, -14f, -9f, 0.75f);
        MoveCloud(Clouds3, -11f, -8f, 0.60f);
        MoveCloud(Clouds2, -9f,-7.5f, 0.45f);
        MoveCloud(Clouds1, -8f,-6.7f, 0.30f);
        MoveCloud(Clouds0, -7.5f, -7.2f, 0.15f);
    }

    private void MoveCloud(List<GameObject> MyList, float YMin, float YMax, float XRate) //Move clouds in Update (NOT FixedUpdate)
    {
        float PlayerXSpeed = GameManager.instance.MyPlayerVelocity.x * Time.deltaTime;
        float PlayerYPos = GameManager.instance.MyPlayer.gameObject.transform.position.y;
        for (int i = 0; i < MyList.Count; i++) 
        {
            float NewXPos = MyList[i].transform.localPosition.x - PlayerXSpeed * XRate;
            float NewYPos = Mathf.Lerp(YMin,YMax,((Mathf.Clamp(PlayerYPos, -27f, 27f) + 27) / 52));
            MyList[i].transform.localPosition = new Vector3(NewXPos, NewYPos, 0f);
            if (MyList[i].transform.localPosition.x < -50)
            {
                MyList[i].transform.localPosition += new Vector3(80, 0, 0);
            }
        }
    }
}
