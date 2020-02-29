using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaveFarm : MonoBehaviour
{
	public string loadingName;
	public string sceneTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
    	FindObjectOfType<CameraFollow>().isFollowing = true;
    	logan_player_controller player = FindObjectOfType<logan_player_controller>();

        player.rb.bodyType = RigidbodyType2D.Dynamic;
        GlobalSceneChange.locationFrom = loadingName;
        GlobalSceneChange.sceneFrom = SceneManager.GetActiveScene().name;
        Debug.Log("Location From:" +GlobalSceneChange.locationFrom);
        Debug.Log("Scene From: " + GlobalSceneChange.sceneFrom);
        SceneManager.LoadScene(sceneTo);
    }
}
