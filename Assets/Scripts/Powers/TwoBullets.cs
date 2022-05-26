using System.Collections;
using UnityEngine;


public class TwoBullets : Power
{
    [SerializeField] private GameObject twoBulletsPrefab;
    public override void OnActivate()
    {
        base.OnActivate();
        hasOnActive = false;

        // Get shooter from player and change prefab
        var shooter = playerController.shooter;
        shooter.ChangeBulletPrefab(twoBulletsPrefab);
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();

        // Get shooter from player and restore prefab
        var shooter = playerController.shooter;
        shooter.RestoreBulletPrefab();
    }
}
