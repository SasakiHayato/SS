using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Attribute
{
    none,
    fire,
    water,
    grass,
    right,
    dark
}

[CreateAssetMenu (fileName = "EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    [SerializeField] List<Data> m_datas = new List<Data>();
    public Data GetData(int id) => m_datas[id];
}

[System.Serializable]
public class Data
{
    /// <summary>名前</summary>
    [SerializeField] string m_name;
    /// <summary>最大HP</summary>
    [SerializeField] int m_maxLife;
    /// <summary>最大MP</summary>
    [SerializeField] int m_maxMagicpoint;
    /// <summary>攻撃力</summary>
    [SerializeField] int m_power;
    /// <summary>魔法攻撃力</summary>
    [SerializeField] int m_magicPower;
    /// <summary>防御力</summary>
    [SerializeField] int m_defence;
    /// <summary>魔法防御力</summary>
    [SerializeField] int m_magicDefence;
    /// <summary>速度</summary>
    [SerializeField] int m_speed;
    /// <summary>クリティカル</summary>
    [SerializeField] float m_critical;
    /// <summary>回避率</summary>
    [SerializeField] float m_avoidance;
    /// <summary>命中率</summary>
    [SerializeField] float m_hit;
    /// <summary>属性</summary>
    [SerializeField] Attribute m_attribute = Attribute.fire;
    /// <summary>キャラクターの絵</summary>
    [SerializeField] Sprite m_sprite;

    public int GetHp { get => m_maxLife; }
    public int GetMp { get => m_maxMagicpoint; }
    public int GetPower { get => m_power; }
    public int GetMagicPower { get => m_magicPower; }
    public int GetDefence { get => m_defence; }
    public int GetMagicDefence { get => m_magicDefence; }
    public int GetSpeed { get => m_speed; }
    public float GetCritical { get => m_critical; }
    public float GetAvoidance { get => m_avoidance; }
    public float GetHit { get => m_hit; }
    public Attribute GetAttribute { get => m_attribute; }
    public Sprite GetSprite { get => m_sprite; }
}
