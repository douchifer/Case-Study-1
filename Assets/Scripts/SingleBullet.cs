using System.Collections;
using UnityEngine;


public class SingleBullet : Bullet
{
    // Just does the default bullet behaviours
    public override void ResetBullet()
    {
        base.ResetBullet();
    }

    public override void FireBullet(Vector3 startPos, float speed, Vector3 dir)
    {
        base.FireBullet(startPos, speed, dir);
    }

}
