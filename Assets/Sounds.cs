using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sounds 
{
    public string Name;
    
    public AudioClip Clip;

    [Range(0 , 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;
   
    public bool loop;

    [HideInInspector]
    public AudioSource source;


}

