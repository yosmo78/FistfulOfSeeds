using UnityEngine.Audio;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	//to access AudioManager
	//FindObjectOfType<AudioManager>().Play("SoundName");
	public Sound[] sounds;

	public static AudioManager instance;

	ConcurrentDictionary<string,Sound> soundMap;

    // Start is called before the first frame update
    void Awake()
    {
    	if(instance == null)
    		instance = this;
    	else
    	{
    		Destroy(gameObject);
    		return;
    	}

    	DontDestroyOnLoad(gameObject);

        int initialCapacity = 101;

        int numProcs = Environment.ProcessorCount;
        int concurrencyLevel = numProcs * 2;

        // Construct the dictionary with the desired concurrencyLevel and initialCapacity
        soundMap = new ConcurrentDictionary<string,Sound>(concurrencyLevel, initialCapacity);

        foreach(Sound s in sounds)
        {
        	s.source = gameObject.AddComponent<AudioSource>();
        	s.source.clip = s.clip;
        	s.source.volume = s.volume;
        	s.source.pitch = s.pitch;
        	s.source.loop = s.loop;
        	soundMap[s.name] = s;
        }
    }

    void Start()
    {
    	//Play("Theme"); //main theme set on looping
    }

	public void Play(string name)
	{
    	try
    	{
    		Sound s = soundMap[name]; 
       		s.source.Play();
       	}
       	catch (KeyNotFoundException  e)
		{
			Debug.LogWarning("Sound: "+name+" not found! "+ e.Message);
        	return;
		}
		catch (ArgumentNullException  e)
		{
			Debug.LogWarning("Sound name is null! "+ e.Message);
        	return;
		}
    }
}
