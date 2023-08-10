using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    private AudioSource gunAudio;
    public float impactStrength = 250f;
    public float range = 30f;
    public float fireRate = .25f;
    private float nextFire;
    private Camera cam;

    void Start()
    {
        cam = GameObject.Find("Player_Eyes").GetComponent<Camera>();
        gunAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            gunAudio.Play();
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactStrength);
                }
            }
        }
    }
}
