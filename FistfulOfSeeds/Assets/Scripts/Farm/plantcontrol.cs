using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantcontrol : MonoBehaviour
{
	public Sprite noPlantObj; 

	// sunflower
	public Sprite sunFlower1;	// sprout 
	public Sprite sunFlower2;	// flower

	// potato
	public Sprite potato1;
	public Sprite potato2;

	// carrot
	public Sprite carrot1;
	public Sprite carrot2;

	public float growTime = 0;

	public Transform plotObj;
	public bool watered = false;

	public string currentSeed = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(currentSeed != "")
    	{
    		growTime += Time.deltaTime;
    	}
    	
    	if((growTime > 5) && (watered == false))
    	{
    		currentSeed = "";
    		growTime = 0;
    		GetComponent<SpriteRenderer>().sprite = noPlantObj;
    	}

    	else if((growTime > 5) && (watered == true))
    	{
    		if(currentSeed == "sunflower")
    		{
    			GetComponent<SpriteRenderer>().sprite = sunFlower2;
    		}

    		else if(currentSeed == "potato")
    		{
    			GetComponent<SpriteRenderer>().sprite = potato2;
    		}

    		else if(currentSeed == "carrot")
    		{
    			GetComponent<SpriteRenderer>().sprite = carrot2;
    		}
    	}

        if(currentSeed == "sunflower" && currentTool == "scythe")
        {
            
        }

    }

    void OnMouseDown()
    {
    	if(GMScript.currentTool == "scythe")
    	{
    		//Destroy(gameObject);
    		GetComponent<SpriteRenderer>().sprite = noPlantObj;
    	}

    	else if((GMScript.currentTool == "sunflower") && 
    			(GetComponent<SpriteRenderer>().sprite == noPlantObj)
    			&& GMScript.sunFlowerSeeds >= 0)
    	{
    		GetComponent<SpriteRenderer>().sprite = sunFlower1;
    		currentSeed = "sunflower";
    		GMScript.sunFlowerSeeds--;
    	}

    	else if((GMScript.currentTool == "carrot") && 
    			(GetComponent<SpriteRenderer>().sprite == noPlantObj)
    			&& GMScript.carrotSeeds >= 0)
    	{
    		GetComponent<SpriteRenderer>().sprite = carrot1;
    		currentSeed = "carrot";
    		GMScript.carrotSeeds--;
    	}

    	else if((GMScript.currentTool == "potato") && 
    			(GetComponent<SpriteRenderer>().sprite == noPlantObj)
    			&& GMScript.potatoSeeds >= 0)
    	{
    		GetComponent<SpriteRenderer>().sprite = potato1;
    		currentSeed = "potato";
    		GMScript.potatoSeeds--;
    	}

    	else if (GMScript.currentTool == "bucket")
    	{
    		plotObj.GetComponent<SpriteRenderer>().color = new Color(127, 76, 12);
    		watered = true;
    	}
    }
}
