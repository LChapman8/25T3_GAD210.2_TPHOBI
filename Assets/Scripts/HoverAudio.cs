using UnityEngine;
using UnityEngine.EventSystems;

public class HoverAudio : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            hoverSound.Play();
    }
}
