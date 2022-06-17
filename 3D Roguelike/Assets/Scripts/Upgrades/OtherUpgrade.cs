using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUpgrade : Upgrade {

    public UpgradeType upgradeType;
    public float toGive;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (!isPlayer) return;

        switch (upgradeType)
        {
            case UpgradeType.SPEED:
                pm.moveSpeed += toGive;
                break;

            case UpgradeType.PROJECTILE_AMOUNT:
                ps.bulletAmount += (int)toGive;
                break;

            case UpgradeType.SHOOT_SPEED:
                ps.fireRate += toGive;
                break;

            default:
                break;
        }

        Die();
    }
}

public enum UpgradeType
{
    SPEED,
    PROJECTILE_AMOUNT,
    SHOOT_SPEED
}
