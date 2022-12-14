using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    float interactRange = 1.0f;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray){
                if (collider.TryGetComponent(out CapsuleInteract capsuleInteract)){
                    capsuleInteract.Interact();
                }
            }
        }
    }

    public CapsuleInteract capsuleInteractObj(){
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
         foreach (Collider collider in colliderArray){
            if (collider.TryGetComponent(out CapsuleInteract capsuleInteract)){
                return capsuleInteract;
            }
        }
        return null;
    }
}
