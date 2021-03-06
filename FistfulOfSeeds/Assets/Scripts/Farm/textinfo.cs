﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textinfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingOrder = 6;
    }

    // Update is called once per frame
    void Update()
    {
    	if(gameObject.name == "sunflowerTxt")
    	{
    		GetComponent<TextMesh>().text = "Sunflower Seeds: " + GMScript.sunFlowerSeeds;    	
    	} 

    	else if(gameObject.name == "potatoTxt")
    	{
    		GetComponent<TextMesh>().text = "Potato Seeds: " + GMScript.potatoSeeds;
    	}

    	else if(gameObject.name == "carrotTxt")
    	{
    		GetComponent<TextMesh>().text = "Carrot Seeds: " + GMScript.carrotSeeds;
    	}  
    }

	void OnMouseDown()
	{
		if(gameObject.name == "sunflowerTxt")
    	{
    		GMScript.currentTool = "sunflower";
    	} 

    	else if(gameObject.name == "potatoTxt")
    	{
    		GMScript.currentTool = "potato";
    	}

    	else if(gameObject.name == "carrotTxt")
    	{
    		GMScript.currentTool = "carrot";
    	}  
	}

}
