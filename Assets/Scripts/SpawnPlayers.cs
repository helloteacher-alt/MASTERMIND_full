using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour
{
    // public Dropdown dropdown;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public float minX;
    public float maxX;
    public float Y;
    public float minZ;
    public float maxZ;
    
    private void Start(){
        checkCharacter();
    }

    private void checkCharacter(){
        if(PlayerPrefs.GetInt("selectedChar")  == 0){
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Y, Random.Range(minZ,maxZ));
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        }
        else if(PlayerPrefs.GetInt("selectedChar")  == 1){
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Y, Random.Range(minZ,maxZ));
            GameObject player = PhotonNetwork.Instantiate(enemyPrefab.name, randomPosition, Quaternion.identity);
        }

    }
}
