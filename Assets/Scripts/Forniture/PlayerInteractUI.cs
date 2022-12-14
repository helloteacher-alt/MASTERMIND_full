using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    void Start(){
        playerInteract = GameObject.FindWithTag("Player").GetComponent<PlayerInteract>();
    }

    private void Update(){
        if (playerInteract.capsuleInteractObj() != null){
            Show();
        }else{
            Hide();
        }
    }

    private void Show(){
        containerGameObject.SetActive(true);
    }

    private void Hide(){
        containerGameObject.SetActive(false);
    }
}
