using System;
using UnityEngine;

public class SoundAction : MonoBehaviour
{
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    public void PlaySound(string soundName)
    {
        audioManager.Play(soundName);
    }
}