using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade {

    public int hpToGive;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (!isPlayer) return;

        ph.health += hpToGive;

        Die();
    }

}
