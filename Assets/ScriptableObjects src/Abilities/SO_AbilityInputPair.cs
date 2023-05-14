using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new ability input pair", menuName ="SO/Abilities/Ability Input Pair")]
public class SO_AbilityInputPair : ScriptableObject
{
    public SO_Ability ability;
    public KeyCode keyCode;
      
}
