using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        StartCoroutine(DelayIt(1)); //multiplayer is set to the next scene build index so we pass down 1 
    }

    public void LoadLocal() 
    {
        StartCoroutine(DelayIt(2)); //the local lobby build index is current build index + 2
    }
    public IEnumerator DelayIt(int index)
    {
        //load the scene asynchrounously, it's important you set allowsceneactivation to false
        //in order to wait for the audioclip to finish playing
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + index);
        sceneLoading.allowSceneActivation = false;

        //wait for the audioclip to end
        yield return new WaitForSeconds(0.2f);
        //wait for the scene to finish loading (it will always stop at 0.9 when allowSceneActivation is false
        while (sceneLoading.progress < 0.9f) yield return null;
        //allow the scene to load
        sceneLoading.allowSceneActivation = true;
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}