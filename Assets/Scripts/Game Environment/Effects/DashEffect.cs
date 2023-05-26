using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    public static void CreateDashEffect(Vector2 position, Vector2 dir, float dashSize)
    {
        //Transform dashTransform = Instantiate(GameAssets.i.pfDashEffect, position, Quaternion.identity);
        //dashTransform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
        //dashTransform.localScale = new Vector3(dashSize, dashSize, 1);
    }
}
