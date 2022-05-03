using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum States {Menu,Game}
    public States CurrentSate;

    public static GameManager instance;
    public float DragonSpeed;
    public Player MyPlayer;
    public Vector2 MyPlayerVelocity;
    public DragonManager MyDragon;
    public CameraMotion MyCameraMotion;
    public int Level;
    public GameObject BigBlood, SmallBlood;

    private void Awake()
    {
        instance = this;
        CurrentSate = States.Menu;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
