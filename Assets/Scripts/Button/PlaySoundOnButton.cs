using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class PlaySoundOnButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public AudioSource hooverSound;
    public AudioSource selectSound;
    public void OnPointerEnter(PointerEventData eventData)
    {
        hooverSound.Play();
    }
    public void OnSelect(BaseEventData eventData)
    {
        selectSound.Play();
    }
}