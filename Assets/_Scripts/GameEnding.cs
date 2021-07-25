using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration;

    private bool isPlayerAtExit;

    public float displayImageDuration = 1f;

    public GameObject Player;

    public CanvasGroup exitCanvasFGroup;
    private float timer;
    
    private void OnTriggerEnter(Collider oter){
        if(oter.gameObject == Player){
            isPlayerAtExit = true;
        }
    }

    private void Update(){
        if(isPlayerAtExit){
            timer += Time.deltaTime;
            exitCanvasFGroup.alpha = Mathf.Clamp(timer/fadeDuration, 0, 1);

            if(timer > fadeDuration * displayImageDuration){
                EndLevel();
            }
        }
    }

    private void EndLevel(){
        Application.Quit();
    }
}
