using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMode : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Ghost;
    private bool _ghostMode = false;
    public float ghostTime = 10f;
    private float _ghostTime;

    private void Awake()
    {
        _ghostTime = ghostTime;
    }
    private void ToggleGhostMode()
    {
        if (!_ghostMode == true)    // Sets the ghost active and swaps controls to it from the normal player
        {
            Ghost.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponentInChildren<AudioListener>().enabled = false;
            
        }
        else
        {
            // Disables the ghost, moves it to player and transfers controls back to normal body
            Ghost.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
            Player.GetComponentInChildren<AudioListener>().enabled = true;
            Ghost.transform.position = Player.transform.position;
        }
        _ghostMode = !_ghostMode;
    }


    void Update()
    {
        if (_ghostMode == true)
        {
           // _ghostTime = ghostTime;

            _ghostTime -= Time.deltaTime;
            if (_ghostTime <= 0.0f)
            {
                Debug.Log("Ghost time ended");
                ToggleGhostMode();
                _ghostTime = ghostTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleGhostMode();
            _ghostTime = ghostTime;
            
        }
    }
}
