using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public DragonScript ParentSeg;
    [SerializeField]
    private GameObject Node;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ParentSeg != null)
        {
            transform.right = ParentSeg.Node.transform.position - transform.position;
            transform.position = (ParentSeg.Node.transform.position + transform.position)/2;
        }
        else 
        {
            transform.position = new Vector3(Time.time * 2, Mathf.Sin(Time.time * 3.1415f * 0.25f) * 2);
        }
    }
}
