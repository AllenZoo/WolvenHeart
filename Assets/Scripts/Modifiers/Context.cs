using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{

    private bool isActive;
    private bool hasDuration;
    private float duration;
    private Condition[] conditions;

    public bool AreConditionsTrue()
    {
        for (int i = 0; i )
        return true;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
