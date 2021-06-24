using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    /// <summary> 攻撃パターン </summary>
    [SerializeField] public Character[] _attackPatterns;
    /// <summary> 名前 </summary>
    [SerializeField] public string _name = "name";
    /// <summary> 最大HP </summary>
    [SerializeField] public int _maxLife = 0;
    /// <summary> 現在HP </summary>
    [SerializeField] public int _life = 0;
    /// <summary> 最大MP </summary>
    [SerializeField] public int _maxMagicpoint = 0;
    /// <summary> 現在MP </summary>
    [SerializeField] public int _magicpoint = 0;
    /// <summary> 攻撃力 </summary>
    [SerializeField] public int _power = 0;
    /// <summary> 防御力 </summary>
    [SerializeField] public int _defence = 0;
    /// <summary> 武器威力 </summary>
    [SerializeField] public int _weapon = 0;
    /// <summary> 防具性能 </summary>
    [SerializeField] public int _armor = 0;

    public int TestAttack()
    {
        return _power;
    }

    public void Damage(int power)
    {
        _life -= power;
        Debug.Log("現在の" + _name + "の体力" + _life);
        if (_life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
