using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GMScript : MonoBehaviour
{

	public Transform grassObj;
    public Transform plotObj;
	public static string currentTool = "none";

    public static int numberOfPlotsWidth = 2;
    public static int numberOfPlotsHeight = 2; 

    public static plotTile[,] farm;

	public static int sunFlowerSeeds = 5;
	public static int potatoSeeds = 4;
	public static int carrotSeeds = 3;
    //public static

    // Start is called before the first frame update
    void Start()
    {
    	for (int xPos = -8; xPos < 10; xPos += 2)
    	{
    		for (int yPos = 5; yPos > -6; yPos -= 2)
    		{
    			Instantiate (grassObj, new Vector2 (xPos, yPos), grassObj.rotation);
    		}
    	} 
        //Instantate plot
        farm = new plotTile[numberOfPlotsWidth, numberOfPlotsHeight];

        for(int i  =  0; i < numberOfPlotsWidth; ++i)
        {
            for(int j = 0 ; j < numberOfPlotsHeight; ++j)
            {
                farm[i, j].plot = Instantiate(plotObj,new Vector2(i,j), new Quaternion(0,0,0,0));  
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
