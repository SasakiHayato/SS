using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int encount;
    
    PlayerController player;
    FadeController fade;

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
            Debug.Log(encount);
        }
        encountBool = false;
    }

    public void Scene()
    {
        SceneManager.LoadScene("ButtleScene");
    }
}
