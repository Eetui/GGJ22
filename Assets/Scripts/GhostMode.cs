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
        CameraController.Instance.SetFollowTarget(Player.transform);
    }
    private void ToggleGhostMode()
    {
        if (!_ghostMode == true && GameManager.Instance.IsPotionPicked)    // Sets the ghost active and swaps controls to it from the normal player
        {
            Ghost.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            CameraController.Instance.SetFollowTarget(Ghost.transform);
            AudioManager.Instance.ChangePitch("Music", 0.3f);
            AudioManager.Instance.Play("Drink");

        }
        else if (_ghostMode && GameManager.Instance.IsPotionPicked)
        {
            // Disables the ghost, moves it to player and transfers controls back to normal body
            Ghost.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
            Ghost.transform.position = Player.transform.position;
            CameraController.Instance.SetFollowTarget(Player.transform);
            AudioManager.Instance.ChangePitch("Music");
            AudioManager.Instance.Play("GhostOff");
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
