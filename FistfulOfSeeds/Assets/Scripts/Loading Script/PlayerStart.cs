using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{

    private logan_player_controller player;
    public string sceneFrom;
    public string pointNameFrom;
    public Vector3 cameraStart; //only used if not following
    // Start is called before the first frame update

    void Start()
    {
        
        if( GlobalSceneChange.sceneFrom.Equals(sceneFrom) &&
            GlobalSceneChange.locationFrom.Equals(pointNameFrom))
        {
            Debug.Log(GlobalSceneChange.sceneFrom);
            Debug.Log(GlobalSceneChange.locationFrom);
            player = FindObjectOfType<logan_player_controller>();
            Debug.Log(player);
            player.transform.position = transform.position;

            if(!FindObjectOfType<CameraFollow>().isFollowing)
            {
                FindObjectOfType<Camera>().transform.position = cameraStart;  
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
