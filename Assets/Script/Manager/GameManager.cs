using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager
{
    int _enemyNumber = 0;
    //static FieldManager fied = null;
    static GameManager instance = new GameManager();
    private GameManager() { }

    static public GameManager GetInstnce() { return instance; }

    public void EncountSet(int enemy)
    {
        instance._enemyNumber = enemy;
    }
    public int EncountGet()
    {
        return instance._enemyNumber;
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
