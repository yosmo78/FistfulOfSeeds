using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tools : MonoBehaviour
{
    public Transform cursorObj;
    public Transform seedInvObj;

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
    	if(gameObject.name == "scythe")
    	{
    		GMScript.currentTool = "scythe";
            seedInvObj.transform.position = new Vector2(-6, 4);
    	}

    	else if(gameObject.name == "seeds")
    	{
            seedInvObj.transform.position = new Vector2(6, -4);
    	}

        else if(gameObject.name == "bucket")
        {
            GMScript.currentTool = "bucket";
            seedInvObj.transform.position = new Vector2(-6, 4);
        }

        cursorObj.transform.position = transform.position;
    	Debug.Log(GMScript.currentTool);
    }
}
