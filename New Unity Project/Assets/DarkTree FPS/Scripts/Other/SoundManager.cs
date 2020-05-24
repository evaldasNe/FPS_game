using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioClip inventoryOpenSound;
    public AudioClip clickSound;
    private float musicVolume = 1f;

    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Pickup()
    {
        source.PlayOneShot(pickupSound);
    }

    public void InventoryOpen()
    {
        source.PlayOneShot(inventoryOpenSound);
    }

    public void Click()
    {
        source.PlayOneShot(clickSound);
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
    private void Update()
    {
        source.volume = musicVolume;
    }

}
