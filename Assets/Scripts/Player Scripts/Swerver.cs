using System.Collections;
using UnityEngine;


public class Swerver : MonoBehaviour
{
    [SerializeField] private float swerveSpeed;
    [SerializeField] private float border;

    private float prevMouseX;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Swerve();
    }


    private void Swerve()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            var currentMouseX = Input.mousePosition.x;
            var difference = currentMouseX - prevMouseX;
            difference /= 5000;
            difference *= swerveSpeed;
            var pos = transform.position;
            pos.x += difference;

            pos.x = Mathf.Clamp(pos.x, -border, border);
            transform.position = pos;
            prevMouseX = currentMouseX;

        }
    }

}
