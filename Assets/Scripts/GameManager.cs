using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum States { Menu, Game }
    public States CurrentState;

    public float Timer;

    public static GameManager instance;
    public float DragonSpeed;
    public Player MyPlayer;
    public Vector2 MyPlayerVelocity;
    public DragonManager MyDragon;
    public CameraMotion MyCameraMotion;
    public GameObject BigBlood, SmallBlood;
    public GameObject Title;

    public int CurrentLevel;
    [System.Serializable]
    public class Level
    {
        public string Name;
        public float Speed;
        public int Length;
        public int[] Pattern;
    }
    public List<Level> Levels;


    private void Awake()
    {
        instance = this;
        CurrentState = States.Menu;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == States.Menu && Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            GameBegin(0,180);
        }
        if (CurrentState == States.Menu && Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameBegin(1, 180);
        }
        else if (CurrentState == States.Game && Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }

        if (CurrentState == States.Game)
        {
            if (Timer >= 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                GameOver();
            }
        }
    }

    public void GameBegin(int Level, float Time) 
    {
        Title.SetActive(false);
        CurrentLevel = Level;
        CurrentState = States.Game;
        Timer = Time;
        MyDragon.SpawnDragon(Levels[Level].Length);
        MyPlayer.Ready();
    }

    public void GameOver() 
    {
        Title.SetActive(true);
        CurrentState = States.Menu;
        MyPlayer.Death();
        MyDragon.DeSpawnDragon();
    }
}
