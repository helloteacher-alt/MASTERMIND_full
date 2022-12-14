using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraEvent : MonoBehaviour
{
    Animator FadeAnim;
    public GameObject fade;
    public GameObject mainCamera;
    public GameObject mainCamera2;
    public GameObject character;
    public GameObject enemy;
    Animator cameraAnim;
    bool isBirdEyeView = false;
    static float t = 0.0f;

    void Start(){
        // character.SetActive(false);
        cameraAnim = mainCamera.GetComponent<Animator>();
        FadeAnim = fade.GetComponent<Animator>();

        if(this.cameraAnim.GetCurrentAnimatorStateInfo(0).IsName("CamAnimation")){
            isBirdEyeView = true;
        }
    }
    void Update() {
        if(isBirdEyeView==true){
            character.transform.position = new Vector3(Mathf.Lerp(0.997f,3f,t),character.transform.position.y,character.transform.position.z);
            t += 0.08f * Time.deltaTime;
        }
    }
    void FinishTransPosition()
    {
        FadeAnim.SetTrigger("FadeOut");
        StartCoroutine(waitbeforechangeposition());
    }

    IEnumerator waitbeforechangeposition(){
        yield return new WaitForSeconds(3f);
        FadeAnim.SetTrigger("FadeIn");
    }

    void LastCameraFinished(){
        character.SetActive(true);
        FadeAnim.SetTrigger("LightOut");
        StartCoroutine(waitbeforenewscene());
    }

    IEnumerator waitbeforenewscene(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Trailer2");
    }

    void CameraRunFinished(){
        mainCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
        mainCamera.GetComponent<CinemachineFreeLook>().enabled = true;
        StartCoroutine(waitbeforeturn());
    }

    IEnumerator waitbeforeturn(){
        yield return new WaitForSeconds(5f);
        character.SetActive(false);
        enemy.transform.position = new Vector3(character.transform.position.x-0.157f, character.transform.position.y, character.transform.position.z);
        mainCamera2.transform.position = new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y-0.05f,mainCamera.transform.position.z);
        enemy.SetActive(true);
        mainCamera.SetActive(false);
        mainCamera2.SetActive(true);
        StopAllCoroutines();
    }
}
