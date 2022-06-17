using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : Upgrade {

    public int weapon;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (!isPlayer) return;

        ps.projectileIndex += weapon;

        Die();
    }
}
