using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNudge : MonoBehaviour
{
    WaitForSeconds pause;
    bool isAnimating = false;

    void Awake(){
        pause = new WaitForSeconds(.04f);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(isAnimating == false){
            if(gameObject.transform.position.x < other.gameObject.transform.position.x){
                StartCoroutine(RotateAntiClock());
            }
            else{
                StartCoroutine(RotateClock());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(isAnimating == false){
            if (gameObject.transform.position.x < other.gameObject.transform.position.x)
            {
                StartCoroutine(RotateAntiClock());
            }
            else
            {
                StartCoroutine(RotateClock());
            }
        }
    }

    IEnumerator RotateAntiClock(){
        isAnimating = true;

        for(int i=0; i<4; i++){
            gameObject.transform.GetChild(0).Rotate(0f,0f,2f); // 반시계방향 돌기
            yield return pause;
        }

        for(int i=0; i<5; i++){
            gameObject.transform.GetChild(0).Rotate(0f,0f, -2f); // 시계방향 돌기
            yield return pause;
        }

        gameObject.transform.GetChild(0).Rotate(0f,0f,2f);
        yield return pause;

        isAnimating = false;
    }

    IEnumerator RotateClock(){
        isAnimating = true;

        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f); // 시계방향 돌기
            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f); // 반시계방향 돌기
            yield return pause;
        }

        gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);
        yield return pause;

        isAnimating = false;
    }
}
