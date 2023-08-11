using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    float health = .4f;
    Rigidbody rb;
    float healthbarTimer = 0;
    [SerializeField]
    Canvas canvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (healthbarTimer > 0)
        {
            healthbarTimer -= Time.deltaTime;
        }
        else if (canvas.enabled)
        {
            canvas.enabled = false;
        }
        
    }

    public void Hit(Vector3 force, float damage)
    {
        if (!canvas.enabled)
        {
            canvas.enabled = true;
            healthbarTimer = 5;
        }

        rb.AddForce(force);
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        } else
        {
            RectTransform healthbar = canvas.gameObject.GetComponentsInChildren<RectTransform>()[1];
            healthbar.sizeDelta = new Vector2(health, 0.02f);
        }
    }
}
