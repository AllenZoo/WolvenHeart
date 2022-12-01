using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ParticleHandler : MonoBehaviour
{
    [SerializeField] private GameObject dashParticle;

    public void SpawnDashParticle(Vector2 dir)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        Vector3 offset = new Vector3(0, 0, 0);

        if (dir == Vector2.right) {
            rotationVector = new Vector3(0, 270, 90);
            offset = new Vector3((float)-0.5, 0, 0);
        } else if (dir == Vector2.up) {
            rotationVector = new Vector3(90, 90, -90);
            offset = new Vector3(0, (float)-0.5, 0);
        } else if (dir == Vector2.left) {
            rotationVector = new Vector3(0, 90, -90);
            offset = new Vector3((float) 0.5, 0, 0);
        } else if (dir == Vector2.down) {
            rotationVector = new Vector3(270, 0, 0);
            offset = new Vector3(0, (float) 0.5, 0);
        }
        Instantiate(dashParticle, this.transform.position + offset, Quaternion.Euler(rotationVector), this.transform);
        //Instantiate(dashParticle, this.transform);
    }
}
