using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    /// <summary>敵を配置する場所</summary>
    private GameObject[] m_enemyPos = new GameObject[2];
    /// <summary>プレイヤーを配置する場所</summary>
    private GameObject[] m_playerPos = new GameObject[0];
    /// <summary>エンカウントした敵番号</summary>
    private int m_enemyNumber;
    /// <summary>背景</summary>
    [SerializeField] private Sprite m_backGround = null;
    /// <summary>プレイヤーのプレハブ</summary>
    [SerializeField] private GameObject[] m_players;
    /// <summary>敵のプレハブ</summary>
    [SerializeField] private GameObject[] m_enemys;
    private BattlePlayer m_player = null;
    private TestEnemy m_enemy = null;
    private bool m_selectTarn = true;
    void Start()
    {
        m_player = m_players[0].GetComponent<BattlePlayer>();
        m_enemy = m_enemys[0].GetComponent<TestEnemy>();
        m_enemyNumber = GameManager.GetInstnce().EncountGet();
        GameObject enemyPositions = GameObject.Find("EnemyPositions");
        m_enemyPos = new GameObject[enemyPositions.transform.childCount];
        for (int i = 0; i < m_enemyPos.Length; i++)
        {
            m_enemyPos[i] = enemyPositions.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < EnemyConvart(m_enemyNumber).Length; i++)
        {
            Instantiate(EnemyConvart(m_enemyNumber)[i], m_enemyPos[i].transform.position, Quaternion.identity);
        }
        GameObject playerPositions = GameObject.Find("PlayerPositions");
        m_playerPos = new GameObject[playerPositions.transform.childCount];
        for (int i = 0; i < m_playerPos.Length; i++)
        {
            m_playerPos[i] = playerPositions.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < m_players.Length; i++)
        {
            Instantiate(m_players[i], m_playerPos[i].transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (m_selectTarn)
        {
            //_selectTarn = false;
        }
    }

    private void BattoleEnd()
    {

    }

    public void PlayerAttack()
    {
        m_enemy.Damage(m_player.NormalAttack());
        EnemyAttack();
    }

    private void EnemyAttack()
    {
        if (m_enemy.m_life <= 0)
        {
            return;
        }
        m_player.Damage(m_enemy.NormalAttack());
    }
    /// <summary>
    /// 受け取ったエンカウントデータを元に、混合した敵を配列に入れなおす
    /// これは混合するエンカウントデータを作る度に更新する必要がある
    /// </summary>
    /// <param name="num">貰った配列番号</param>
    /// <returns>出現させる敵</returns>
    private GameObject[] EnemyConvart(int num)
    {
        GameObject[] g;
        if (num == 2) { g = new GameObject[] { m_enemys[0], m_enemys[1] }; }
        else { g = new GameObject[] { m_enemys[num] }; }
        return g;
    }
}
