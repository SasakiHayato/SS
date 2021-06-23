using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float step;

    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(h / 16, v / 16, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            step += Time.deltaTime;
            Debug.Log(step);
        }
    }
}
