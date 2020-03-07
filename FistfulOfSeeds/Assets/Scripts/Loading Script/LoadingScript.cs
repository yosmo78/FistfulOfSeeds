using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            if (sceneTo.Equals("Farm"))
            {
                FindObjectOfType<CameraFollow>().isFollowing = false;
                collision.attachedRigidbody.bodyType = RigidbodyType2D.Static;
            }
            GlobalSceneChange.locationFrom = loadingName;
            GlobalSceneChange.sceneFrom = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneTo);
        }
    }
}
