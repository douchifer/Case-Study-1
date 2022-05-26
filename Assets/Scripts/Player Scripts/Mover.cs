using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private float defaultSpeedValue;
    public float speed { get; private set; }

    private bool moveEnabled;
    void Start()
    {
        GetValues();
        RestoreSpeedValue();
    }

    private void GetValues()
    {
        // Get values from game data
        defaultSpeedValue = GameManager.gameData.defaultMoveSpeed;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(!moveEnabled) return;

        if(Input.GetMouseButton(0))
        {
            var moveVec = transform.forward * speed * Time.deltaTime;
            transform.position += moveVec;
        }
        
    }

    public void ChangeSpeedValue(float spd) => speed = spd;
    public void RestoreSpeedValue() => speed = defaultSpeedValue;

    private void GameStarted()
    {
        moveEnabled = true;
    }

    private void OnEnable()
    {
        EventManager.gameStarted += GameStarted;
    }

    private void OnDisable()
    {
        EventManager.gameStarted -= GameStarted;
    }
}
