using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{

    private logan_player_controller player;
    public string sceneFrom;
    public string pointNameFrom;
    // Start is called before the first frame update
    void Start()
    {
        if(GlobalSceneChange.sceneFrom.Equals(sceneFrom) &&
            GlobalSceneChange.locationFrom.Equals(pointNameFrom))
        {
            player = FindObjectOfType<logan_player_controller>();
            player.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
