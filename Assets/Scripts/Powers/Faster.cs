using System.Collections;
using UnityEngine;


public class Faster : Power
{
   public override void OnActivate()
    {
        base.OnActivate();
        hasOnActive = false;

        // Get mover from player and update speed
        var mover = playerController.mover;
        var speed = mover.speed * 2;
        mover.ChangeSpeedValue(speed); 
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();

        // Get mover from player and restore speed
        var mover = playerController.mover;
        mover.RestoreSpeedValue();
    }


}
