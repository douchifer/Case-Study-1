using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPool : MonoBehaviour
{
    private GameObject singleBulletPrefab;
    private GameObject multipleBulletsPrefab;
    private Queue<Bullet> singleBulletsPool = new Queue<Bullet>();
    private Queue<Bullet> multipleBulletsPool = new Queue<Bullet>();


    private void Start()
    {
        GetValues();
    }

    private void GetValues()
    {
        singleBulletPrefab = GameManager.gameData.singleBullet;
        multipleBulletsPrefab = GameManager.gameData.multipleBullets;
    }
    private void PutBulletInThePool(Bullet bullet)
    {
        // Puts the bullet corresponding pool
        if(bullet.gameObject.CompareTag("SingleBullet"))
        {
            singleBulletsPool.Enqueue(bullet);
            bullet.ResetBullet();
        }

        else if(bullet.gameObject.CompareTag("MultipleBullets"))
        {
            multipleBulletsPool.Enqueue(bullet);
            bullet.ResetBullet();
        }
    }

    private Bullet GetBulletFromThePool(GameObject bullet)
    {
        // Checks the requested bullet and gives required bullet
        if (bullet.gameObject.CompareTag("SingleBullet"))
        {
            var blt = GetSingleBullet();
            return blt;
        }

        else if (bullet.gameObject.CompareTag("MultipleBullets"))
        {
            var blt = GetMultipleBullets();
            return blt;
        }

        return null;
    }

    private Bullet GetSingleBullet()
    {
        // If pool doesnt have required bullet than creates and sends one otherwise sends the one at hand
        if(singleBulletsPool.Count != 0)
        {
            return singleBulletsPool.Dequeue();
        }

        var bullet = Instantiate(singleBulletPrefab).GetComponent<Bullet>();
        bullet.ResetBullet();

        return bullet;
    }

    private Bullet GetMultipleBullets()
    {
        // If pool doesnt have required bullet than creates and sends one otherwise sends the one at hand
        if (multipleBulletsPool.Count != 0)
        {
            return multipleBulletsPool.Dequeue();
        }

        var bullet = Instantiate(multipleBulletsPrefab).GetComponent<Bullet>();
        bullet.ResetBullet();

        return bullet;
    }

    private void OnEnable()
    {
        EventManager.putBulletToThePool = PutBulletInThePool;
        EventManager.getBulletFromThePool = GetBulletFromThePool;
    }
}
