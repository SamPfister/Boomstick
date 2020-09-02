using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;
    public Camera fpsCam;
<<<<<<< HEAD
    public float gunForce = 2000f;
=======
    public float gunForce = 1000f;
    public ParticleSystem muzzleFlash;
>>>>>>> cefc114d0f61cec02cb6ec7b456dd6d172d91797

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            UnityEngine.Debug.Log(hit.transform.name);
        }
        if(hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * gunForce);
        }
    }
}
