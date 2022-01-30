using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public bool IsPotionPicked { get; set; }

    [SerializeField] private ImageFade imageFade;

    private void Start()
    {
        SceneManager.sceneLoaded += FadeIn;
        
        FadeIn(SceneManager.GetActiveScene());

        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1) IsPotionPicked = true;
    }

    private void FadeIn(Scene arg0, LoadSceneMode arg1 = LoadSceneMode.Additive)
    {
        if (imageFade == null) 
        {
            Wait(0.1f, () => imageFade.FadeIn(2f));
        }
        else 
        {
            imageFade.FadeIn(2f);
        }
    }

    private void FadeOut(Action callback)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) 
        {
            
            var playerMovement = FindObjectOfType<PlayerController>();
            var ghostMode = FindObjectOfType<GhostMode>();
            playerMovement.enabled = false;
            ghostMode.enabled = false;
        }

        imageFade.FadeOut(2f, callback);
    }

    public void NextScene()
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        FadeOut(() => SceneManager.LoadScene(nextScene));
    }

    private IEnumerable Wait(float duration, Action callback = null)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
