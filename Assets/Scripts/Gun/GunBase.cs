using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunBase : MonoBehaviour
{   
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweentShoot = .3f;
    public Transform PlayerSideReference;

    private Coroutine _currentCoroutine;

    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
           StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweentShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = PlayerSideReference.transform.localScale.x;
    }
}
