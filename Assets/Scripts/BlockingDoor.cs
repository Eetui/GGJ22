using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingDoor : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite doorClose;
    [SerializeField] private Sprite doorOpen;

    private bool isOpen;

    public void UseDoor()
    {
        isOpen = !isOpen;
        sr.sprite = isOpen ? doorOpen : doorClose;
        bc.enabled = !isOpen;
    }
}
