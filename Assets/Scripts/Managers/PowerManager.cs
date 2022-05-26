using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class PowerManager : MonoBehaviour
{

    private List<Power> activatedPowers = new List<Power>();
    private List<Power> allPowers = new List<Power>();

    private bool powersLocked;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PowerActivated(Power power)
    {
        activatedPowers.Add(power);
    }

    private void PowerDeactivated(Power power)
    {
        if(activatedPowers.Contains(power))
            activatedPowers.Remove(power);
    }

    private int GetActivatedPowerCount ()
    {
        return activatedPowers.Count;
    }


    private void CheckOnPowers()
    {
        if (activatedPowers.Count >= 3 && !powersLocked)
            LockPowers();
        else if(powersLocked)
            UnlockPowers();
        
    }

    private void LockPowers()
    {
        powersLocked = true;
        foreach (var power in allPowers)
        {
            // Lock all which are inactive
            if(!power.isPowerActive)
                power.LockPower();
        }
    }

    private void UnlockPowers()
    {
        powersLocked = false;
        foreach (var power in allPowers)
        {
            // Unlock all which are locked
            if (power.isLocked)
                power.UnlockPower();
        }
    }

    private void PutPowerToList(Power power)
    {
        if(!allPowers.Contains(power))
            allPowers.Add(power);
    }

    private void OnEnable()
    {
        EventManager.powerActivated += PowerActivated;
        EventManager.powerDeactivated += PowerDeactivated;

        EventManager.getActivatedPowerCount = GetActivatedPowerCount;

        EventManager.checkOnPowers = CheckOnPowers;

        EventManager.putPowerToList = PutPowerToList;
    }

    private void OnDisable()
    {
        EventManager.powerActivated -= PowerActivated;
        EventManager.powerDeactivated -= PowerDeactivated;

    }


}
