using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided with " + col.name);
        AudioManager.Instance.Play("PotionGrab");
        GameManager.Instance.IsPotionPicked = true;
        Destroy(gameObject);
    }
}
