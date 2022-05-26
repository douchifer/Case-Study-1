using System.Collections;
using UnityEngine;
using System;


public class EventManager
{
    public static Action<Power> powerActivated;
    public static Action<Power> powerDeactivated;
    public static Func<int> getActivatedPowerCount;
    public static Func<PlayerController> getPlayerController;


    public static Action checkOnPowers;

    public static Action<Power> putPowerToList;

    public static Action<Bullet> putBulletToThePool;
    public static Func<GameObject, Bullet> getBulletFromThePool;
}
