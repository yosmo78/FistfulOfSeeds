using UnityEngine.Audio;
using UnityEngine;

//Serializable makes it so that the custom object can be viewed in the inspector
[System.Serializable]
public class Sound
{
	public string name;

	public AudioClip clip;

	//add slider in Inspector
	[Range(0f,1f)]
	public float volume;
	[Range(.1f,3f)]
	public float pitch;

	public bool loop;

	//hides the source object from the Inspector
	[HideInInspector]
	public AudioSource source;

}
