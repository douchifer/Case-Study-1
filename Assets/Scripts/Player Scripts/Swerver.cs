using System.Collections;
using UnityEngine;


public class Swerver : MonoBehaviour
{
    private float swerveSpeed;
    private float border;
    private bool swerveEnabled;

    private float prevMouseX = Mathf.NegativeInfinity;

    void Start()
    {
        GetValues();
    }

    private void GetValues()
    {
        swerveSpeed = GameManager.gameData.swerveSpeed;
        border = GameManager.gameData.swerveBorder;
    }

    void Update()
    {
        Swerve();
    }


    private void Swerve()
    {
        if (!swerveEnabled) return;

        if (Input.GetMouseButtonDown(0))
        {
            prevMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            // if when mouse button clicked couldnt get mouse x position set it
            if (prevMouseX <= Mathf.NegativeInfinity) prevMouseX = Input.mousePosition.x;
            // Set current mouse x position
            var currentMouseX = Input.mousePosition.x;

            // Get difference of previous frame's mouse x position and current frame's mouse x position
            var difference = currentMouseX - prevMouseX;

            // Making the value smaller to edit better
            difference /= 5000;

            // Factor difference with speed and create a move vector
            difference *= swerveSpeed;
            var pos = transform.position;
            pos.x += difference;

            // Clamp the vector to make the character stay inside of the borders
            pos.x = Mathf.Clamp(pos.x, -border, border);

            // Update position
            transform.position = pos;

            // Save mouse x position for next frame
            prevMouseX = currentMouseX;

        }
    }

    private void GameStarted()
    {
        swerveEnabled = true;
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
