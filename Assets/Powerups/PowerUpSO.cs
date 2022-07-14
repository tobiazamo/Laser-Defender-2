using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpSO : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
