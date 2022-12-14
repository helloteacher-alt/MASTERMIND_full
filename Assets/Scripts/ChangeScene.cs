using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartGame(){
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene(){
        yield return new WaitForSeconds(2); 
        SceneManager.LoadScene("Loading");
    }

    public void BackToGame(){
        SceneManager.LoadScene("SampleScene");
    }
    
}