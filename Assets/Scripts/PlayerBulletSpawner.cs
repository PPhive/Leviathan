using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public List<GameObject> BulletList;

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject NewBullet = Instantiate(BulletPrefab); ;
            BulletList.Add(NewBullet);
            NewBullet.SetActive(false);
        }
    }

    public void Fire() 
    {
        for (int i = 0; i < BulletList.Count; i++) 
        {
            PlayerBullet BulletScript = BulletList[i].GetComponent<PlayerBullet>();
            if (!BulletList[i].activeSelf) 
            {
                BulletList[i].SetActive(true);
                BulletList[i].transform.position = transform.position;
                BulletList[i].transform.rotation = transform.rotation;
                BulletList[i].transform.eulerAngles += new Vector3(0, 0, Random.Range(-2f, 2f));
                BulletScript.Timer = 1.5f;
                i = BulletList.Count;
            }
        }
    }
}
