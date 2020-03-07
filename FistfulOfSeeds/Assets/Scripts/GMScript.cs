using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;

public class CSVHelper : List<string[]>
{
  protected string csv = string.Empty;
  protected string separator = ",";

  public CSVHelper(string csv, string separator = "\",\"")
  {
    this.csv = csv;
    this.separator = separator;
    List<string> list = new List<string>(Regex.Split(csv, System.Environment.NewLine));
    foreach(string line in list)
    {
        if(!string.IsNullOrEmpty(line))
        {

            string[] values = Regex.Split(line, separator);

            for (int i = 0; i < values.Length; i++)
            {
                //Debug.Log("value "+values[i]);
                 //Trim values
                values[i] = values[i].Trim('\"');
            }

            this.Add(values);
            
        }
    }
  }
}


public class GMScript : MonoBehaviour
{

	public Transform grassObj;
    public Transform plotObj;
    public GameObject plant;
	public static string currentTool = "none";

    public static int numberOfPlotsWidth = 2;
    public static int numberOfPlotsHeight = 2; 

    public static plotTile[,] farm = null;

	public static int sunFlowerSeeds = 5;
	public static int potatoSeeds = 4;
	public static int carrotSeeds = 3;
    //public static

    private static bool existsInScene;

    static plotTile[,] init_farm(int numberOfPlotsWidth, int numberOfPlotsHeight, Transform plotObj, GameObject plant)
    {
        Debug.Log("Ran init farm");
        //TODO: need to init from file if file exists
        plotTile[,] farm1 = null;
        if(File.Exists("farmtmp.txt"))
        {
            Debug.Log("Ran read farm");
            farm1 = read_farm_from_file("farmtmp.txt", ref numberOfPlotsWidth, ref numberOfPlotsHeight,plotObj,plant);
        //Instantate plot
        }
        else
        {
            Debug.Log("Ran first time farm");
            farm1 = new plotTile[numberOfPlotsWidth, numberOfPlotsHeight];

            for(int i  =  0; i < numberOfPlotsWidth; ++i)
            {
                for(int j = 0 ; j < numberOfPlotsHeight; ++j)
                {
                    farm1[i, j] = new plotTile();
                    farm1[i, j].plot = Instantiate(plotObj,new Vector2(i,j), new Quaternion(0,0,0,0));  
                    farm1[i, j].plant = Instantiate(plant,new Vector2(i,j), new Quaternion(0,0,0,0));  
                    farm1[i, j].plant.GetComponent<plantcontrol>().plotObj = farm1[i, j].plot;
                }
            }
        }
        return farm1;
    }

    public static plotTile[,] read_farm_from_file(string file_name, ref int numberOfPlotsWidth,ref int numberOfPlotsHeight,Transform plotObj, GameObject plant)
    {
        plotTile[,] farm1 = null;

        using (System.IO.StreamReader file = 
            new System.IO.StreamReader(@file_name))
        {

            string csvContent;
            while ((csvContent = file.ReadLine()) != null) 
            {
                //Debug.Log(csvContent);

                CSVHelper csv = new CSVHelper(csvContent,",");
                foreach(string[] line in csv)
                {
                    /*
                    foreach(string word in line)
                    {
                        Debug.Log(word+" ");
                    }
                    */
                    if(line[0] == "NumberOfPlots")
                    {
                        numberOfPlotsWidth = int.Parse(line[1]);
                        numberOfPlotsHeight = int.Parse(line[2]);
                        farm1 = new plotTile[numberOfPlotsWidth, numberOfPlotsHeight];
                        Debug.Log("Set Number of Plots: "+numberOfPlotsWidth+" "+numberOfPlotsHeight);
                    }
                    else
                    {
                        int i = int.Parse(line[0]);
                        int j = int.Parse(line[1]);
                        Debug.Log("Instantiated Farm Plot "+i+","+j);
                        farm1[i, j] = new plotTile();
                        farm1[i, j].plot = Instantiate(plotObj,new Vector2(i,j), new Quaternion(0,0,0,0));  
                        farm1[i, j].plant = Instantiate(plant,new Vector2(i,j), new Quaternion(0,0,0,0));  
                        farm1[i, j].plant.GetComponent<plantcontrol>().plotObj = farm1[i, j].plot;
                        farm1[i, j].plant.GetComponent<plantcontrol>().watered = (line[2] == "T"? true : false);
                        if(farm1[i, j].plant.GetComponent<plantcontrol>().watered)
                        {
                            farm1[i, j].plot.GetComponent<SpriteRenderer>().color = new Color(127, 76, 12);
                        }
                        farm1[i, j].plant.GetComponent<plantcontrol>().growTime = float.Parse(line[3]);
                        switch(line[4])
                        {
                            case "sunFlower":
                                if(System.Int32.Parse(line[5]) == 2)
                                {
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().sunFlower2;
                                }
                                else
                                {
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().sunFlower1;
                                }
                                farm1[i, j].plant.GetComponent<plantcontrol>().currentSeed = "sunflower";
                                break;
                            case "carrot":
                                if(System.Int32.Parse(line[5]) == 2)
                                {
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().carrot2;
                                }
                                else
                                {
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().carrot1;
                                }
                                farm1[i, j].plant.GetComponent<plantcontrol>().currentSeed = "carrot";
                                break;
                            case "potato":
                                if(System.Int32.Parse(line[5]) == 2)
                                {
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().potato2;
                                }
                                else
                                {
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().potato1;
                                }
                                farm1[i, j].plant.GetComponent<plantcontrol>().currentSeed = "potato";
                                break;
                            case "noPlant":
                                    farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite = farm1[i, j].plant.GetComponent<plantcontrol>().noPlantObj;
                                break;
                            case "weed":
                                break;
                        }

                    }
                }

            }

        }
        return farm1;

    }




    public static void write_farm_to_file(string file_name, plotTile[,] farm1, int numberOfPlotsWidth, int numberOfPlotsHeight)
    {
        Debug.Log("Ran write farm");

        using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@file_name))
        {

            file.WriteLine("NumberOfPlots,"+numberOfPlotsWidth+","+numberOfPlotsHeight);
            for(int i  =  0; i < numberOfPlotsWidth; ++i)
            {
                for(int j = 0 ; j < numberOfPlotsHeight; ++j)
                {
                    string currentPlant = i+","+j+",";
                    currentPlant += (farm1[i, j].plant.GetComponent<plantcontrol>().watered?"T,":"F,");
                    currentPlant += farm1[i, j].plant.GetComponent<plantcontrol>().growTime+",";

                    if(farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite == farm1[i, j].plant.GetComponent<plantcontrol>().noPlantObj)
                    {
                        currentPlant += "noPlant";
                    }
                    else if(farm1[i, j].plant.GetComponent<plantcontrol>().currentSeed == "sunflower")
                    {

                        currentPlant += "sunFlower,";
                        if(farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite == farm1[i, j].plant.GetComponent<plantcontrol>().sunFlower1)
                        {
                            currentPlant += "1";
                        }
                        else
                        {
                            currentPlant += "2";
                        }
                    }
                    else if(farm1[i, j].plant.GetComponent<plantcontrol>().currentSeed == "potato" )
                    {

                        currentPlant += "potato,";
                        if(farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite == farm1[i, j].plant.GetComponent<plantcontrol>().potato1)
                        {
                            currentPlant += "1";
                        }
                        else
                        {
                            currentPlant += "2";
                        }
                    }
                    else if(farm1[i, j].plant.GetComponent<plantcontrol>().currentSeed == "carrot" )
                    {

                        currentPlant += "carrot,";
                        if(farm1[i, j].plant.GetComponent<SpriteRenderer>().sprite == farm1[i, j].plant.GetComponent<plantcontrol>().carrot1)
                        {
                            currentPlant += "1";
                        }
                        else
                        {
                            currentPlant += "2";
                        }
                    }
                    else
                    {
                        currentPlant += "weed";
                    }
                    Debug.Log(currentPlant+'\n');
                    file.WriteLine(currentPlant);
                }
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {


        Debug.Log("Ran Start");

        farm = init_farm(numberOfPlotsWidth,numberOfPlotsHeight,plotObj,plant);
        //call func below in leaveFarm.cs file
    	for (int xPos = -8; xPos < 10; xPos += 2)
    	{
    		for (int yPos = 5; yPos > -6; yPos -= 2)
    		{
    			Instantiate (grassObj, new Vector2 (xPos, yPos), grassObj.rotation);
    		}
    	} 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


