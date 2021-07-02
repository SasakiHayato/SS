using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum EnemyData
{
    Waru = 0,
    aaa = 1,
    Waruxaaa = 2,
}
public class FieldManager : MonoBehaviour
{
    private int encount;
    private int _enemyCount;

    PlayerController player;
    FadeController fade;

    [SerializeField] private GameObject enemy;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        fade = this.gameObject.AddComponent<FadeController>();

        player.isPlayer = true;
    }

    void Update()
    {
        RandomEncounter();

        if (encount == player.encount)
        {
            player.isPlayer = false;
            fade.FadeOut();
            _enemyCount = Random.Range((int)EnemyData.Waru, (int)EnemyData.Waruxaaa + 1);

            if (fade.isScene)
            {
                GameManager.GetInstnce().EncountSet(_enemyCount);
                Scene();
            }
        }
    }

    private bool encountBool = true;

    private void RandomEncounter()
    {
        if (encountBool)
        {
            encount = Random.Range(1, 3);
        }
        encountBool = false;
    }

    public void Scene()
    {
        SceneManager.LoadScene("ButtleScene");
    }
}
