using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private AudioSource gunAudio;
    public float impactStrength = 250f;
    public float range = 30f;
    public float fireRate = .25f;
    private float nextFire;
    private int ammo = 5;
    private Camera cam;
    public TMP_Text ammoIndicator;

    void Start()
    {
        cam = GameObject.Find("Player_Eyes").GetComponent<Camera>();
        gunAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ammo > 0 && Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            nextFire = Time.time + fireRate;
            gunAudio.Play();
            ammo--;
            Debug.Log(ammo);
            ammoIndicator.text = "Ammo: " + ammo;


            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.GetComponent<Can>().Hit(-hit.normal * impactStrength, .1f);
                }
            }
        }
    }

    public void Reload(int bullets)
    {
        ammo += bullets;
        Debug.Log(ammo);
        ammoIndicator.text = "Ammo: " + ammo;
    }
}
