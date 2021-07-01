using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldManager : MonoBehaviour
{
    private int encount;

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

            if (fade.isScene)
            {
                GameManager.GetInstnce().Set(enemy);
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
