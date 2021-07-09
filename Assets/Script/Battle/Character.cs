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

public class Character : MonoBehaviour
{
    /// <summary>攻撃パターン</summary>
    [SerializeField] public Character[] m_attackPatterns;
    /// <summary>名前</summary>
    [SerializeField] public string m_name = "name";
    /// <summary>最大HP</summary>
    [SerializeField] public int m_maxLife = 0;
    /// <summary>現在HP</summary>
    [SerializeField] public int m_life = 0;
    /// <summary>最大MP</summary>
    [SerializeField] public int m_maxMagicpoint = 0;
    /// <summary>現在MP</summary>
    [SerializeField] public int m_magicpoint = 0;
    /// <summary>攻撃力</summary>
    [SerializeField] public int m_power = 0;
    /// <summary>魔法攻撃力</summary>
    [SerializeField] public int m_magicPower = 0;
    /// <summary>防御力</summary>
    [SerializeField] public int m_defence = 0;
    /// <summary>魔法防御力</summary>
    [SerializeField] public int m_magicDefence = 0;
    /// <summary>速度</summary>
    [SerializeField] public int m_speed = 0;
    /// <summary>クリティカル</summary>
    [SerializeField] public float m_critical = 0f;
    /// <summary>回避率</summary>
    [SerializeField] public float m_avoidance = 0f;
    /// <summary>命中率</summary>
    [SerializeField] public float m_hit = 0f;
    /// <summary>属性</summary>
    [SerializeField] public Attribute m_attribute = Attribute.fire;
    /// <summary>ダメージ量を表示するテキスト</summary>
    [SerializeField] private Text _text;

    /// <summary>通常攻撃</summary>
    /// <returns>ダメージ量</returns>
    public int NormalAttack()
    {
        return m_power;
    }

    public void Damage(int power)
    {
        int damage = power - m_defence;
        if (damage <= 0) { damage = 1; }
        m_life -= damage;
        Debug.Log("現在の" + m_name + "の体力" + m_life);
        if (m_life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
