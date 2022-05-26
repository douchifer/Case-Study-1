using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class MultipleBullets : Bullet
{
    [SerializeField] private List<Bullet> bullets = new List<Bullet>();


    public override void ResetBullet()
    {
        base.ResetBullet();

        // Enable single bullets which are inside of this bullet
        foreach (var bullet in bullets)
        {
            bullet.gameObject.SetActive(false);
        }
    }
    public override void FireBullet(Vector3 startPos, float speed, Vector3 dir)
    {
        base.FireBullet(startPos, speed, dir);

        // Disable single bullets which are inside of this bullet
        foreach (var bullet in bullets)
        {
            bullet.gameObject.SetActive(true);
        }
    }
}
