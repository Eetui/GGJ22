using System;
using UnityEngine;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    public Sound[] sounds;
    
    internal override void OnAwake()
    {
        foreach (var sound in sounds) 
        {
            var s = sound.Source = gameObject.AddComponent<AudioSource>();
            s.clip = sound.AudioClip;
            s.loop = sound.loop;
            s.volume = sound.volume;
            s.pitch = sound.pitch;
        }
    }

    public void Play(string soundName)
    {
        var sound = Array.Find(sounds, sound => sound.Name == soundName);
        
        if (sound == null) 
        {
            Debug.LogWarning($"No sound with name {soundName}");
            return;
        }
        
        sound.Source.Play();
    }

    public void Mute(string soundName, bool mute)
    {
        var sound = Array.Find(sounds, sound => sound.Name == soundName);
        
        if (sound == null) 
        {
            Debug.LogError($"No sound with name {soundName}");
            return;
        }

        sound.Source.mute = mute;
    }

    public void MuteAll(bool mute)
    {
        foreach (var sound in sounds) 
        {
            sound.Source.mute = mute;
        }
    }

    public void ChangePitch(string soundName, float pitch = 1f)
    {
        var sound = Array.Find(sounds, sound => sound.Name == soundName);
        
        if (sound == null) 
        {
            Debug.LogError($"No sound with name {soundName}");
            return;
        }
        
        sound.Source.pitch = pitch;
    }
}
