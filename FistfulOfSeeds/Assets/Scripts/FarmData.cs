using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmData : MonoBehaviour
{
	public static bool existsInScene;
	public static int numberOfPlotsWidth;
	public static int numberOfPlotsHeight;
	public static CropInfo[,] farm = null;

    static FarmData()
    {
        existsInScene = false;
        numberOfPlotsWidth = 2;
        numberOfPlotsHeight = 2;
    }


    // Start is called before the first frame update
    void Start()
    {
        /* Check to see if Farm exists, and if so, don't create a new one */
        if (!existsInScene)
        {
            existsInScene = true;
            DontDestroyOnLoad(transform.gameObject);
            farm = new CropInfo[numberOfPlotsHeight, numberOfPlotsWidth];
            for(int i = 0; i < numberOfPlotsHeight; ++i)
            {
            	for(int j = 0; j < numberOfPlotsWidth; ++j)
            	{
            		farm[i, j] = new CropInfo();
            		farm[i, j].watered = false;
            		farm[i, j].growTime = 0;
            		farm[i, j].seedType = "";
            		farm[i, j].growthStage = 0;
            	}
            }

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

