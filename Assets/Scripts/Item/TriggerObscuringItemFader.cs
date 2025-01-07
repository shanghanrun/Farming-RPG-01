using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObscuringItemFader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        ObscuringItemFader[] obscuringItemFaders = other.GetComponentsInChildren<ObscuringItemFader>();

        if(obscuringItemFaders.Length >0){
            foreach( ObscuringItemFader fader in obscuringItemFaders){
                fader.FadeOut();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        ObscuringItemFader[] obscuringItemFaders = other.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders.Length > 0)
        {
            foreach (ObscuringItemFader fader in obscuringItemFaders)
            {
                fader.FadeIn();
            }
        }
    }
}
