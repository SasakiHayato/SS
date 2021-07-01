using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPos;
    GameObject enemy;

    [SerializeField] Sprite _backGround = null;
    [SerializeField] GameObject[] _players = null;
    [SerializeField] GameObject[] _enemys = null;
    BattlePlayer _player = null;
    TestEnemy _enemy = null;
    bool _playerTarn = false;
    bool _enemyTarn = false;
    //敵のチップデータの作成お願いします
    void Start()
    {
        _player = _players[0].GetComponent<BattlePlayer>();
        _enemy = _enemys[0].GetComponent<TestEnemy>();
        //_playerTarn = true;


        
        enemy = GameManager.GetInstnce().Get();
        Instantiate(enemy, enemyPos.transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }

    public void PlayerAttack()
    {
        _enemy.Damage(_player.TestAttack());
        //_playerTarn = false;
        //_enemyTarn = true;
        EnemyAttack();
    }

    private void EnemyAttack()
    {
        if (_enemy._life <= 0)
        {
            return;
        }
        _player.Damage(_enemy.TestAttack());
    }
}
