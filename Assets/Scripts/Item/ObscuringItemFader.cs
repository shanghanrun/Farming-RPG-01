using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObscuringItemFader : MonoBehaviour
{
    SpriteRenderer sr;

    void Awake(){
        sr = GetComponent<SpriteRenderer>();
    }

    public void FadeOut(){
        StartCoroutine(nameof(FadeOutRoutine));
    }
    public void FadeIn(){
        StartCoroutine(nameof(FadeInRoutine));
    }

    IEnumerator FadeOutRoutine(){
        float currentAlpha = sr.color.a;
        float distance = currentAlpha - Settings.targetAlpha;

        while(currentAlpha - Settings.targetAlpha > 0.01f){
            currentAlpha -= distance / Settings.fadeOutSeconds * Time.deltaTime;
            sr.color = new Color(1f,1f,1f, currentAlpha);
            yield return null;
        }
        sr.color = new Color(1f,1f,1f, Settings.targetAlpha);
    }
    IEnumerator FadeInRoutine(){
        float currentAlpha = sr.color.a;
        float distance = 1f - currentAlpha;

        while(1f - currentAlpha > 0.01f){
            currentAlpha += distance / Settings.fadeInSeconds * Time.deltaTime;
            sr.color = new Color(1f,1f,1f, currentAlpha);
            yield return null;
        }
        sr.color = new Color(1f,1f,1f, 1f);
    }
}
