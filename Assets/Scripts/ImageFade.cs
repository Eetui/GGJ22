using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color fadeIn;
    [SerializeField] private Color fadeOut;
    
    public void FadeIn(float duration, Action callback = null)
    {
        StartCoroutine(FadeImage(fadeIn, duration, callback));
    }

    public void FadeOut(float duration, Action callback = null)
    {
        StartCoroutine(FadeImage(fadeOut, duration, callback));
    }
    
    private IEnumerator FadeImage(Color endValue, float duration, Action callback)
    {
        float time = 0;
        Color startValue = image.color;

        while (time < duration)
        {
            image.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        image.color = endValue;
        callback?.Invoke();
    }
}
