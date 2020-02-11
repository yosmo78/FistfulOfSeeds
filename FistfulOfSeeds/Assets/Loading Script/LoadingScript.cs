using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public string sceneToLoad;
    public string locationName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            GlobalSceneChange.locationFrom = locationName;
            GlobalSceneChange.sceneFrom = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
