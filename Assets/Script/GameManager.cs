using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int encount;
    private bool encountBool = true;

    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        RandomEncounter();

        if (encount < player.step)
        {
            Scene();
        }
    }

    private void RandomEncounter()
    {
        if (encountBool)
        {
            encount = Random.Range(1, 3);
            Debug.Log(encount);
        }

        encountBool = false;
    }

    public void Scene()
    {
        SceneManager.LoadScene("ButtleScene");
    }
}
