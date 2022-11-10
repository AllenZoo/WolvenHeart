using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Set default dir to downwards (0, -1)
    private Vector2 curDir = Vector2.down;

    // Tracks the last dir where player faced
    private Vector2 lastDir = Vector2.down;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    public void MovePlayer(float x, float y, float speed)
    {
        if (x == 1 || y == 1)
        {
            lastDir = new Vector2(x, y);
        } else if (x == 0 && y == 0)
        {
            curDir = lastDir;
        }

        this.transform.Translate(new Vector3(x*speed, y*speed, 0));
    }

    public void Dash(float range, float dir)
    {
        if (dir == 1)
        {
            // dash forward
            Debug.Log("Dashing forwards " + range + " pixels");
            this.transform.Translate(new Vector3(this.transform.position.x, this.transform.position.y - 1, 0));
            //rb.AddForce(new Vector2(range * dir, 0f), ForceMode2D.Impulse);

        } else if (dir == -1)
        {
            // dash backwards
        }
    }
}
