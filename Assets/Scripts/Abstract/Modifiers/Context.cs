using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{

    [SerializeField] private bool isActive;
    [SerializeField] private bool hasDuration;
    [SerializeField] private float duration;
    [SerializeField] private Condition[] conditions;

    public bool AreConditionsTrue()
    {
        return true;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
