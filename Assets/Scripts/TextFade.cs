using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    [SerializeField] private TMP_Text textToFade;

    [SerializeField] private Color fadeIn;
    [SerializeField] private Color fadeOut;

    public void FadeOut(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(LerpFunction(fadeOut, duration));
    }
    
    public void FadeIn(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(LerpFunction(fadeIn, duration));
    }

    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = textToFade.color;

        while (time < duration)
        {
            textToFade.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        textToFade.color = endValue;
    }
}
