using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip AudioClip;
    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool loop;
    public AudioSource Source { get; set; }
}
