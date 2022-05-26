using System.Collections;
using UnityEngine;


public class MoreBullets : Power
{
    private float improvedShootInterval;

    public override void Start()
    {
        base.Start();
        improvedShootInterval = GameManager.gameData.improvedShootInterval;
    }
    public override void OnActivate()
    {
        base.OnActivate();
        hasOnActive = false;

        // Get shooter from player and update shoot interval
        var shooter = playerController.shooter;
        shooter.ChangeShootInterval(improvedShootInterval);

    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();

        // Get shooter from player and restore shoot interval
        var shooter = playerController.shooter;
        shooter.RestoreShootInterval();
    }
}
