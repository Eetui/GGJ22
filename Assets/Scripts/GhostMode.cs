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

    // Update is called once per frame
    void Update()
    {
        if (_ghostMode == true)    // Sets the ghost active and swaps controls to it from the normal player
        {
            
            Ghost.SetActive(true);
            Ghost.GetComponent<PlayerController>().enabled = true;
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponentInChildren<AudioListener>().enabled = false;
        }
        else
        {
            Ghost.SetActive(false);
            Ghost.GetComponent<PlayerController>().enabled = false;
            Player.GetComponent<PlayerController>().enabled = true;
            Player.GetComponentInChildren<AudioListener>().enabled = true;
            Ghost.transform.position = Player.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(_ghostMode == false) { _ghostMode = true; }
            else { _ghostMode = false; }
        }
    }
}
