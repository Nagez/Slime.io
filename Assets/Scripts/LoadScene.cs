using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    /*
    public void LoadNextScene()
    {

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public IEnumerator LoadNextScene()
 {
     yield return new WaitForSeconds(3);
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

} *//*
    public void LoadNextScene()
 {
        Debug.Log("delay1");
        StartCoroutine(DelayIt());       
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
 }
private IEnumerator DelayIt()
{
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
}
    

    public IEnumerator ChangeScene()
    {
    float duration = btnAudio.clip.length;
    btnAudio.PlayOneShot(btnAudio.clip);

    //load the scene asynchrounously, it's important you set allowsceneactivation to false
    //in order to wait for the audioclip to finish playing
    AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("newScene");
    sceneLoading.allowSceneActivation = false;

    //wait for the audioclip to end
    yield return new WaitForSeconds(duration);
    //wait for the scene to finish loading (it will always stop at 0.9 when allowSceneActivation is false
    while (sceneLoading.progress < 0.9f) yield return null;
    //allow the scene to load
    sceneLoading.allowSceneActivation = true;
}*/
    public void LoadNextScene()
    {
        StartCoroutine(DelayIt());
    }
    public IEnumerator DelayIt()
    {
        //Debug.Log("delay2");
        //load the scene asynchrounously, it's important you set allowsceneactivation to false
        //in order to wait for the audioclip to finish playing
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        sceneLoading.allowSceneActivation = false;

        //wait for the audioclip to end
        yield return new WaitForSeconds(0.2f);
        //wait for the scene to finish loading (it will always stop at 0.9 when allowSceneActivation is false
        while (sceneLoading.progress < 0.9f) yield return null;
        //allow the scene to load
        sceneLoading.allowSceneActivation = true;
    }
}