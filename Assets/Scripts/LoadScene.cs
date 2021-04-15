using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNextScene()
    {

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*
private IEnumerator WaitForSceneLoad()
 {
     yield return new WaitForSeconds(0.1f);
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

} 
 private void LoadNextScene()
 {
    DelayIt();
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
}
private IEnumerator DelayIt()
{
    yield return new WaitForSeconds(0.1f);
}
private IEnumerator ChangeScene()
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
}