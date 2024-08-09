using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : ScriptableObject
{
    public abstract void Apply(GameObject player);
}
