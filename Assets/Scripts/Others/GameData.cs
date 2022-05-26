using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Mover Values")]
    public float defaultMoveSpeed;

    [Header("Shooter Values")]
    public GameObject defaultBulletPrefab;
    public float defaultShootInterval;
    public float defaultBulletSpeed;
    public float bulletLifeTime;

    [Header("Swerver Values")]
    public float swerveSpeed;
    public float swerveBorder;

    [Header("Powers")]
    [Header("More Bullets")]
    public float improvedShootInterval;

    [Header("Two Bullets")]
    public GameObject twoBulletsPrefab;

    [Header("Bullet Pool")]
    public GameObject singleBullet;
    public GameObject multipleBullets;

}
