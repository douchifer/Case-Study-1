using System.Collections;
using UnityEngine;


public class FasterBullets : Power
{
    public override void OnActivate()
    {
        base.OnActivate();
        hasOnActive = false;

        // Get shooter from player and update bullet speed
        var shooter = playerController.shooter;
        var speed = shooter.bulletSpeed + (shooter.bulletSpeed / 2);
        shooter.ChangeBulletSpeed(speed);
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
        // Get shooter from player and restore bullet speed
        var shooter = playerController.shooter;
        shooter.RestoreBulletSpeed();
    }
}
