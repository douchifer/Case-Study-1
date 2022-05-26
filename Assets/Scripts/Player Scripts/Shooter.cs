using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject defaultBulletPrefab;
    public GameObject bulletPrefab { get; private set; }
    public Action shootAction;

    [HideInInspector] public bool shootEnabled;

    [SerializeField] private float defaultShootInterval;
    public float shootInterval { get; private set; }
    private float currentShootTime;


    [SerializeField] private float defaultBulletSpeed;
    public float bulletSpeed { get; private set; }


    public float bulletLifeTime;
    public Transform nozzle;

    void Start()
    {
        SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        // Restore default values
        RestoreBulletPrefab();
        RestoreShootInterval();
        RestoreBulletSpeed();

        // Subscribe default shoot function to shoot Action
        shootAction += DefaultShoot;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (currentShootTime > 0)
        {
            currentShootTime -= Time.deltaTime;
            return;
        }

        currentShootTime = shootInterval;

        shootAction?.Invoke();
    }



    private void DefaultShoot()
    {
        // Get bullet from pool and fire it
        var bullet = EventManager.getBulletFromThePool(bulletPrefab);
        bullet.FireBullet(nozzle.transform.position, bulletSpeed, nozzle.transform.forward);

        // Pools the bullet after a certain time
        bullet.PoolTheBullet(bulletLifeTime);

    }

    public void ChangeBulletPrefab(GameObject prefab) => bulletPrefab = prefab;
    public void RestoreBulletPrefab() => bulletPrefab = defaultBulletPrefab;


    public void ChangeShootInterval(float interval) => shootInterval = interval;
    public void RestoreShootInterval() => shootInterval = defaultShootInterval;

    public void ChangeBulletSpeed(float speed) => bulletSpeed = speed;
    public void RestoreBulletSpeed() => bulletSpeed = defaultBulletSpeed;
}
