using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Event : MonoBehaviour
{
    public GameObject enemy;
    public GameObject BlackScreen;
    void TurnCompleted(){
        enemy.GetComponent<Animator>().SetTrigger("Attack");
        StartCoroutine(blackScreenShow());
    }

    IEnumerator blackScreenShow(){
        yield return new WaitForSeconds(0.7f);
        BlackScreen.SetActive(true);
    }
}
