using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new modifier", menuName ="SO/Modifier")]
public class Modifier : ScriptableObject
{
    Context context;
    Feedback feedback;
    EValidActors actorSelector;
    IEffect[] effects;

}

public enum EValidActors
{
    Player,
    Enemy
}
