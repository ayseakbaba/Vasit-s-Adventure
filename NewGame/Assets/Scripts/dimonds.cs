using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimonds : MonoBehaviour
{
    [SerializeField] private AudioClip dimondSound;
    private int count=0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectible"))
        {
            count++;
            AudioSource.PlayClipAtPoint(dimondSound, col.transform.position);
            Destroy(col.gameObject);
        }
    }
}
