using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    public override void Die() {
        base.Die();

        LevelManager.instance.enemiesInRoom.Remove(this.gameObject);

        Destroy(gameObject);
    }
}