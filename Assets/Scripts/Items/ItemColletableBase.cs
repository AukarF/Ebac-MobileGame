using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemColletableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioSource audioSource2;

    private void Awake()
    {
        //if (particleSystem != null) particleSystem.transform.SetParent(null);

    }

    private void OnTriggerEnter (Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {

        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() 
    {
        if (particleSystem != null) particleSystem.Play();

        if (audioSource != null) audioSource.Play();
        if (audioSource2 != null) audioSource2.Play();

        if (audioSource != null && audioSource.enabled)
        {
            particleSystem.transform.SetParent(null);
            audioSource.Play();
        }

        if (audioSource2 != null && audioSource2.enabled)
        {
            audioSource2.Play();
        }
    }
}

