using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite lockedSprite;

    [HideInInspector] public bool hasOnActive;

    public bool isPowerActive { get; private set; }
    public bool isLocked { get; private set; }

    private Image image;
    internal  PlayerController playerController;

    private void Start()
    {
        // Get Imager component
        image = GetComponent<Image>();

        // Set default sprite
        image.sprite = defaultSprite;

        // Get player controller
        playerController = EventManager.getPlayerController?.Invoke();

        // Put this power to the list in power manager
        EventManager.putPowerToList?.Invoke(this);
    }

    // This function will not be overritten
    public void PowerSelected()
    {
        // If power is locked do nothing
        if (isLocked)
            return;

        // Get the count of activated powers
        var activePowerCount = EventManager.getActivatedPowerCount?.Invoke();


        // The case of not getting anything return
        if (activePowerCount == null)
        {
            Debug.LogError("did not get anything");
            return;
        }

        // If there are already 3 powers in use and selected power is not activated return
        // If a power is already activated you can deactivate
        if (activePowerCount >= 3 && !isPowerActive)
            return;

        // Change the bool which tells us whether the power is active or not
        isPowerActive = !isPowerActive;

        // Change the sprite of the image
        image.sprite = isPowerActive ? activeSprite : defaultSprite;


        // If we activated this power
        if(isPowerActive)
        {
            // Activate power
            OnActivate();
        }

        // if we deactivated this power
        else
        {
            // Deactivate Power
            OnDeactivate();

        }


        // Tell power manager to check on powers
        EventManager.checkOnPowers?.Invoke();
    }

    public void LockPower()
    { 
        isLocked = true;

        // Change the sprite
        image.sprite = lockedSprite;
    }

    public void UnlockPower()
    {
        isLocked = false;

        // Change the sprite
        image.sprite = defaultSprite;
    }

    virtual public void OnActivate()
    {
        EventManager.powerActivated?.Invoke(this);

    }


    virtual public void OnActive()
    {

    }



    virtual public void OnDeactivate()
    {
        EventManager.powerDeactivated?.Invoke(this);
    }

}
