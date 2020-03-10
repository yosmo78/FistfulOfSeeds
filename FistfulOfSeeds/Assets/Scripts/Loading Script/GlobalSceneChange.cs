using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSceneChange : MonoBehaviour
{
    public static string sceneFrom;
    public static string locationFrom;
    // Start is called before the first frame update

    private void Awake()
    {
        sceneFrom = null;
        locationFrom = null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
