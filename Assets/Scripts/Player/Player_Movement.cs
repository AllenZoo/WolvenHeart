using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    
    public void MovePlayer(float x, float y, float speed)
    {
        this.transform.Translate(new Vector3(x*speed, y*speed, 0));
    }
}
