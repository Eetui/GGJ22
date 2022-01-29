using System;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private bool mute;
    private string music = "Music1";
    private void Start()
    {
        AudioManager.Instance.Play(music);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C)) 
        {

            AudioManager.Instance.MuteAll(mute);
            mute = !mute;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            AudioManager.Instance.ChangePitch(music, 0.3f);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            AudioManager.Instance.ChangePitch(music);
        }
    }
}
