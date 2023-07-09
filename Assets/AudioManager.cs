using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] sound;

    private void Start()
    {
       play("MainTheme");
    }

    private void Awake()
    {
        instance = this;
        foreach (Sounds s in sound) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;
        }
    }

    public void play(string name) 
    {
       Sounds s =  Array.Find(sound, Sounds => Sounds.Name == name);
        s.source.Play();
    }

    public void stop(string name)
    {
        Sounds s = Array.Find(sound, Sounds => Sounds.Name == name);
        s.source.Stop();
    }

}
