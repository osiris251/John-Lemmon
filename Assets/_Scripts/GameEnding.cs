using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration;

    private bool isPlayerAtExit, isPlayerCaught;

    public float displayImageDuration = 1f;

    public GameObject Player;

    public CanvasGroup exitCanvasFGroup;
    public CanvasGroup exitImageFGroup;

    public CanvasGroup caughtCanvasFGroup;
    public CanvasGroup caughtImageFGroup;

    public AudioSource exitAudio, coughtAudio;
    public bool hasAudioPlay;

    private float timer;
    
    private void OnTriggerEnter(Collider oter){
        if(oter.gameObject == Player){
            isPlayerAtExit = true;
        }
    }

    private void Update(){
        if(isPlayerAtExit){
            EndLevel(exitCanvasFGroup, exitImageFGroup, false, exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtCanvasFGroup, caughtImageFGroup, true, coughtAudio);
        }
    }

    /// <summary>
    /// Lanza la imagen del fin de la partida
    /// </summary>
    /// <param name="imageCanvasGroup">imagen de fin de pantalla correspondiente</param>
    private void EndLevel(CanvasGroup PanelCanvasFGroup, CanvasGroup imageCanvasFGroup, bool doRestart, AudioSource audioSource){
        timer += Time.deltaTime;

        imageCanvasFGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);
        PanelCanvasFGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);

        if (!hasAudioPlay)
        {
            audioSource.Play();
            hasAudioPlay = true;
        }

        if (timer > fadeDuration + displayImageDuration)
        {
            if(doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void CatchPlayer(){
        isPlayerCaught = true;
    }
}
