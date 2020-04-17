using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio_pickup : MonoBehaviour
{
    private AudioSource song;
    private bool wasPlayed = false;
    void Awake()
    {
        song = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !wasPlayed)
        {
            song.Play();
            wasPlayed = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }    
    }
}
