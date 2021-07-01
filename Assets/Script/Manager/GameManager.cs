using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager
{
    GameObject game = null;
    //static FieldManager fied = null;
    static GameManager instance = new GameManager();
    private GameManager() { }

    static public GameManager GetInstnce() { return instance; }

    public void Set(GameObject enemy)
    {
        instance.game = enemy;
    }
    public GameObject Get()
    {
        return instance.game;
    }
    //static public GameManager Instance
    //{
    //    get
    //    {
    //        if (fied == null)
    //        {
    //            fied = GameObject.FindObjectOfType<FieldManager>();

    //            if (fied )
    //            {

    //            }
    //        }

    //        return instance;
    //    }
    //}
}
