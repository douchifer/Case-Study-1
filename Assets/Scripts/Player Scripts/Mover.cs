using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] private float defaultSpeedValue;
    public float speed { get; private set; }

    void Start()
    {
        RestoreSpeedValue();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetMouseButton(0))
        {
            var moveVec = transform.forward * speed * Time.deltaTime;
            transform.position += moveVec;
        }
        
    }

    public void ChangeSpeedValue(float spd) => speed = spd;
    public void RestoreSpeedValue() => speed = defaultSpeedValue;
}
