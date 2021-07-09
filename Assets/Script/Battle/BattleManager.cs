using UnityEngine;
using UnityEngine.UI;

enum Faze
{
    Battle = 0,
    Action = 1,
    EnemySelect,
    Skill,
    Item
}

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
    [SerializeField] private GameObject[] m_playerPrefabs;
    /// <summary>インスタンス化されているプレイヤー</summary>
    private GameObject[] m_players = new GameObject[2];
    /// <summary>各プレイヤーのパラメーター</summary>
    private BattlePlayer[] m_playerStates = new BattlePlayer[2];
    /// <summary>敵のプレハブ</summary>
    [SerializeField] private GameObject[] m_enemyPrefabs;
    /// <summary>インスタンス化されている敵</summary>
    private GameObject[] m_enemys = new GameObject[2];
    /// <summary>各敵のパラメーター</summary>
    private EnemyBase[] m_enemyStates = new EnemyBase[2];
    /// <summary>コマンド選択の遷移</summary>
    private Faze m_faze = Faze.Battle;
    /// <summary>選択中のテキストのインデックス番号</summary>
    private int select = 0;
    /// <summary>キャンバス</summary>
    private GameObject m_canvas;
    //以下ウィンドウ達
    private GameObject m_selectWindow1;
    private Text[] m_text1 = new Text[1];
    private GameObject m_selectWindow2;
    private Text[] m_text2 = new Text[2];
    private GameObject m_stateWindow;
    private Text[] m_stateView = new Text[2];
    void Start()
    {
        m_enemyNumber = GameManager.GetInstnce().EncountGet();
        //m_enemyNumber = 1;

        //ゲームウィンドウと操作するテキストの取得
        m_canvas = GameObject.Find("Window");
        m_selectWindow1 = m_canvas.transform.GetChild(0).gameObject;
        m_text1 = new Text[m_selectWindow1.transform.childCount];
        for (int i = 0; i < m_text1.Length; i++)
        {
            m_text1[i] = m_selectWindow1.transform.GetChild(i).GetComponent<Text>();
        }
        m_selectWindow2 = m_canvas.transform.GetChild(1).gameObject;
        m_text2 = new Text[m_selectWindow2.transform.childCount];
        for (int i = 0; i < m_text2.Length; i++)
        {
            m_text2[i] = m_selectWindow2.transform.GetChild(i).GetComponent<Text>();
        }
        m_stateWindow = m_canvas.transform.GetChild(2).gameObject;
        for (int i = 0; i < m_stateView.Length; i++)
        {
            m_stateView[i] = m_stateWindow.transform.GetChild(i).GetComponent<Text>();
        }

        //敵グループの配置
        GameObject enemyPositions = GameObject.Find("EnemyPositions");
        m_enemyPos = new GameObject[enemyPositions.transform.childCount];
        for (int i = 0; i < m_enemyPos.Length; i++)
        {
            m_enemyPos[i] = enemyPositions.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < EnemyConvart(m_enemyNumber).Length; i++)
        {
            m_enemys[i] = Instantiate(EnemyConvart(m_enemyNumber)[i], m_enemyPos[i].transform.position, Quaternion.identity);
            m_enemyStates[i] = m_enemys[i].GetComponent<EnemyBase>();
        }
        //味方グループの配置
        GameObject playerPositions = GameObject.Find("PlayerPositions");
        m_playerPos = new GameObject[playerPositions.transform.childCount];
        for (int i = 0; i < m_playerPos.Length; i++)
        {
            m_playerPos[i] = playerPositions.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < m_playerPrefabs.Length; i++)
        {
            m_players[i] = Instantiate(m_playerPrefabs[i], m_playerPos[i].transform.position, Quaternion.identity);
            m_playerStates[i] = m_players[i].GetComponent<BattlePlayer>();
        }
    }

    void Update()
    {
        //テキストに味方のHPを表示
        m_stateView[0].text = $"{m_playerStates[0].m_name} HP{m_playerStates[0].m_life}/{m_playerStates[0].m_maxLife}";

        CommandSelect();
    }

    private void CommandSelect()
    {
        //たたかう、にげるのコマンド選択処理
        if (m_faze == Faze.Battle)
        {
            m_selectWindow1.SetActive(true);
            m_selectWindow2.SetActive(false);
            if (Input.GetKeyDown(KeyCode.UpArrow)) { select--; }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { select++; }
            if (select >= m_text1.Length) { select = 0; }
            if (select < 0) { select = 1; }
            for (int i = 0; i < m_text1.Length; i++)
            {
                var r = m_text1[i];
                r.color = i == select ? Color.red : Color.white;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (select == 0)
                {
                    //たたかう
                    m_faze++;
                }
                else
                {
                    //にげる
                }
                select = 0;
                return;
            }
        }
        //戦闘の行動選択処理
        if (m_faze == Faze.Action)
        {
            m_selectWindow1.SetActive(false);
            m_selectWindow2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.UpArrow)) { select--; }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { select++; }
            if (select >= m_text2.Length) { select = 0; }
            if (select < 0) { select = 2; }
            for (int i = 0; i < m_text2.Length; i++)
            {
                var r = m_text2[i];
                r.color = i == select ? Color.red : Color.white;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (select == 0)
                {
                    //攻撃
                    PlayerAttack();
                }
                if (select == 1)
                {
                    //スキル
                }
                if (select == 2)
                {
                    //アイテム
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                m_faze--;
            }
            return;
        }
    }

    private void BattleEnd()
    {

    }

    public void PlayerAttack()
    {
        m_enemyStates[0].Damage(m_playerStates[0].NormalAttack());
        EnemyAttack();
    }

    private void EnemyAttack()
    {
        if (m_enemyStates[0].m_life <= 0) { return; }
        m_playerStates[0].Damage(m_enemyStates[0].NormalAttack());
    }

    /// <summary>
    /// 受け取ったエンカウントデータを元に敵を配列に入れなおす
    /// これは混合するエンカウントデータを作る度に更新する必要がある
    /// </summary>
    /// <param name="num">貰った配列番号</param>
    /// <returns>出現させる敵</returns>
    private GameObject[] EnemyConvart(int num)
    {
        GameObject[] g;
        if (num == 2) { g = new GameObject[] { m_enemyPrefabs[0], m_enemyPrefabs[1] }; }
        else { g = new GameObject[] { m_enemyPrefabs[num] }; }
        return g;
    }

    /// <summary>
    /// 数秒間待ってほしい時に仕える便利な関数
    /// </summary>
    /// <param name="waitTime">待ってほしい時間</param>
    private void Wait(float waitTime)
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                return;
            }
        }
    }
}
