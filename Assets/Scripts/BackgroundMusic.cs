using System;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private string music = "Music";
    private void Start()
    {
        AudioManager.Instance.Play(music);
    }
}
