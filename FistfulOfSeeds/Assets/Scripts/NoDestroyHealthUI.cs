using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyHealthUI : MonoBehaviour
{
  	public static bool existsInScene = false;

    // Start is called before the first frame update
    void Start()
    {
  		if(!existsInScene)
        {
            existsInScene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
