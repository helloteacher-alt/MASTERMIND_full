using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerHealth : MonoBehaviour
{
    public GameObject Player;
    Animator animator;
    CharacterController controller;
    PlayerMovement playerMovement;
    public int health = 0;
    public int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        animator = Player.GetComponent<Animator>();
        controller = Player.GetComponent<CharacterController>();
        playerMovement = Player.GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int amount){
        health -= amount;
        if(health <= 0){
            Debug.Log("Dead");
            animator.SetBool("Dead",true);
            controller.enabled = false;
            playerMovement.enabled = false;
        }
    }
}
