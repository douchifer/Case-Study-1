using System.Collections;
using UnityEngine;


public class DiagonalBullets : Power
{
    private Shooter shooter;
    public override void OnActivate()
    {
        base.OnActivate();
        hasOnActive = false;

        // Get shoter from player and add to Action
        shooter = playerController.shooter;

        shooter.shootAction += DiagonalShoot;
    }

    private void DiagonalShoot()
    {
        // Get nozzle
        var nozzle = shooter.nozzle;
        // Get bullet lifeTime
        var bltLifeTime = shooter.bulletLifeTime;
        // Get bullet
        var bullet = EventManager.getBulletFromThePool(shooter.bulletPrefab);
        // Get speed
        var speed = shooter.bulletSpeed;

        // LeftDirection
        var dir = nozzle.transform.forward + (nozzle.transform.right * -1);
        var normalizedDir = dir.normalized;
        bullet.FireBullet(nozzle.transform.position, speed, normalizedDir);
        bullet.PoolTheBullet(bltLifeTime);

        // Get another bullet
        bullet = EventManager.getBulletFromThePool(shooter.bulletPrefab);

        // RightDirection
        dir = nozzle.transform.forward + nozzle.transform.right;
        normalizedDir = dir.normalized;
        bullet.FireBullet(nozzle.transform.position, speed, normalizedDir);
        bullet.PoolTheBullet(bltLifeTime);

    }



    public override void OnDeactivate()
    {
        base.OnDeactivate();
        shooter.shootAction -= DiagonalShoot;

    }
}

