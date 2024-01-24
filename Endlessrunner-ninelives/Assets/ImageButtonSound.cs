using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageButtonSound : MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Register this script for the button's click event
        Image imageButton = GetComponent<Image>();

        // Add this script as an event listener to the button's click event
        EventTrigger trigger = imageButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { PlayButtonSound(); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Play the button sound when the button is clicked
        PlayButtonSound();
    }

    private void PlayButtonSound()
    {
        // Play the button sound
        audioSource.Play();
    }
}
