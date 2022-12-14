using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_Text dropdown;
    public InputField createInput;
    public InputField joinInput;

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom(){
        DropdownSelected(dropdown);
        PhotonNetwork.LoadLevel("SampleScene");
    }

    private void DropdownSelected(TMP_Text dropdown){
        if(dropdown.text  == "Player"){
            PlayerPrefs.SetInt("selectedChar",0);
        }
        else if(dropdown.text  == "Enemy"){
            PlayerPrefs.SetInt("selectedChar",1);
        }
    }

}
