using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Shooter shooter { get; private set; }
    public  Mover mover { get; private set; }
    public Swerver swerver { get; private set; }
    void Start()
    {
        // Get Components
        shooter = GetComponent<Shooter>();
        mover = GetComponent<Mover>();
        swerver = GetComponent<Swerver>();

    }

    private PlayerController GetPlayerController()
    {
        return this;
    }

    private void OnEnable()
    {
        EventManager.getPlayerController = GetPlayerController;
    }
}
