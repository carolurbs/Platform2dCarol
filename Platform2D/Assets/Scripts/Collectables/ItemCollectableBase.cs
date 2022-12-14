using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase: MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem _particleSystem;
    [Header("Sounds")]
    public AudioSource audioSource;
    private void Awake()
    {
        if (_particleSystem != null)   _particleSystem.transform.SetParent(null);
        if (audioSource != null) audioSource.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        Debug.Log("Collect");
        gameObject.SetActive(false);
        OnCollect();
    }
    protected virtual void OnCollect()
    {
    if (_particleSystem != null) _particleSystem.Play();
       if (audioSource != null) audioSource.Play();




    }

}
