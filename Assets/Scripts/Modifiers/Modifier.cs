using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new modifier", menuName ="SO/Modifier")]
public class Modifier : ScriptableObject
{
    [SerializeField] Context context;
    [SerializeField] Feedback feedback;
    [SerializeField] EValidActors[] actorSelector;
    [SerializeField] IEffect[] effects;

}

public enum EValidActors
{
    Player,
    Enemy
}
