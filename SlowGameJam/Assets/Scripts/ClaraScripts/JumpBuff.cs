using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/JumpBuff")]
public class JumpBuff : PowerUpBase
{
    public float amount;
    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerControllerNew>().JumpPU();
    }
}
