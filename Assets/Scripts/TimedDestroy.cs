using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField]
    float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
