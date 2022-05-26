using System.Collections;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private Vector3 offset;
    void Start()
    {
        // Get offset from player
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = player.transform.position - offset;
    }
}
