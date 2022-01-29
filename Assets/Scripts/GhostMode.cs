using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMode : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Ghost;
    private bool _ghostMode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void ToggleGhostMode()
    {
        if (!_ghostMode == true)    // Sets the ghost active and swaps controls to it from the normal player
        {
            _ghostMode = true;
            Ghost.SetActive(true);
            Ghost.GetComponent<PlayerController>().enabled = true;
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponentInChildren<AudioListener>().enabled = false;
        }
        else
        {
            // Disables the ghost, moves it to player and transfers controls back to normal body
            _ghostMode = false;
            Ghost.SetActive(false);
            Ghost.GetComponent<PlayerController>().enabled = false;
            Player.GetComponent<PlayerController>().enabled = true;
            Player.GetComponentInChildren<AudioListener>().enabled = true;
            Ghost.transform.position = Player.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleGhostMode();
        }
    }
}
