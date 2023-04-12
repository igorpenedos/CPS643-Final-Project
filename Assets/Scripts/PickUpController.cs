using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private float respawnTimer;

    private bool destroyAndRespawn = false;

    private new Renderer[] renderer;

    void Start()
    {
        renderer = gameObject.transform.GetComponentsInChildren<Renderer>();
    }

    public void DestroyAndRespawn()
    {
        destroyAndRespawn = true;

        foreach (Renderer r in renderer)
        {
            r.enabled = false;
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(Time.deltaTime * 50, 0f, Time.deltaTime * 50);

        if (destroyAndRespawn)
        {
            respawnTimer += Time.deltaTime;
            destroyAndRespawn = false;
        }

        if (respawnTimer >= 4f)
        {
            foreach (Renderer r in renderer)
            {
                r.enabled = true;
            }
            respawnTimer = 0f;
        } 
        else if (respawnTimer > 0f)
        {
            respawnTimer += Time.deltaTime;
        }
    }
}
