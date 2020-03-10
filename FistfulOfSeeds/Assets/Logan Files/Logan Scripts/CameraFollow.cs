using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public bool isFollowing; //used to determine if the camera is following the player of not

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private static bool existsInScene;

    private void Start()
    {
        if (!existsInScene)
        {
            existsInScene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        if (isFollowing)
        {
            Vector3 newPosition;
            newPosition.x = target.position.x + offset.x;
            newPosition.y = target.position.y + offset.y;
            newPosition.z = transform.position.z + offset.z;
            transform.position = newPosition;
        }
    }
}
