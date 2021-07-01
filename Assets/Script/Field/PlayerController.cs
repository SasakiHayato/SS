using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.NonSerialized] public int encount = 0;
    [System.NonSerialized] public bool isPlayer = false;
    // PlayerPosition
    Vector3 target;
    void Start()
    {
        target = this.transform.position;
    }

    // Tile間を移動する速さ
    private float speed = 5f;
    void Update()
    {
        if (!isPlayer) return;

        if (this.transform.position == target)
        {
            Move();
        }
        
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
    }
    /// <summary>
    /// playerの動きを制御
    /// </summary>
    private bool x;
    private bool y;
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h == 0 && v == 0)
        {
            x = false;
            y = false;
        }
        else if (h != 0)
        {
            x = true;
            Encount();
        }
        else if (v != 0)
        {
            y = true;
            Encount();
        }

        if (!y)
        {
            if (h > 0)
            {
                target.x += 1f;
            }
            if (h < 0)
            {
                target.x -= 1f;
            }
        }

        if (!x)
        {
            if (v > 0)
            {
                target.y += 1f;
            }
            if (v < 0)
            {
                target.y -= 1f;
            }
        }
    }

    public void Encount()
    {
        encount++;
    }
}
