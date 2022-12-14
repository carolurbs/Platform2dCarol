using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour

{
    public SOInt ammo;
    public ProjectileBase prefabProjectille;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    private Coroutine _currentCoroutine;
    public Transform playerSideReference;
    public AudioSource audioSource;
    // Update is called once per frame
    void Update()
    {
        if (ammo.value > 0)
        {

            if (Input.GetKeyDown(KeyCode.S))
            {

                _currentCoroutine = StartCoroutine(StartShoot());
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
            }
        }
        else
        {
            StopCoroutine(_currentCoroutine);
        }
    }
    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
            if(audioSource!=null)audioSource.Play();
        }
    }
    public void Shoot()
    {
        var projectille = Instantiate(prefabProjectille);
        projectille.transform.position = positionToShoot.position;
        projectille.side= playerSideReference.transform.localScale.x;
        ammo.value--;
    }
 
}
