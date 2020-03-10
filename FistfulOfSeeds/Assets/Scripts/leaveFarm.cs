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

        //need to write farm to file here
        GMScript.write_farm_to_file("farmtmp.txt",GMScript.farm,GMScript.numberOfPlotsWidth,GMScript.numberOfPlotsHeight);

        GlobalSceneChange.sceneFrom = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneTo);
    }
}
