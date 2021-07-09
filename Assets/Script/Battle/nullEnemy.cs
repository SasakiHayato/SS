using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nullEnemy : MonoBehaviour
{
    //配列の使われないインデックスに入れる本来呼ばれる事の無いプレハブ
    void Start()
    {
        Debug.LogError("BattleManagerのEnemy呼び出しエラー");
    }
}
