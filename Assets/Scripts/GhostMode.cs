using UnityEngine;

public class GhostMode : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Ghost;
    private bool _ghostMode = false;
    public float ghostTime = 10f;
    private float _ghostTime;

    private void Start()
    {
        _ghostTime = ghostTime;
        CameraController.Instance.SetFollowTarget(Player.transform);
    }
    private void ToggleGhostMode()
    {
        if (!GameManager.Instance.IsPotionPicked) return;
        
        if (!_ghostMode == true)    // Sets the ghost active and swaps controls to it from the normal player
        {
            Ghost.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
            CameraController.Instance.SetFollowTarget(Ghost.transform);
            AudioManager.Instance.ChangePitch("Music", 0.3f);
            AudioManager.Instance.Play("Drink");
            playerAnim.SetBool("GhostMode", true);
        }
        else  // Disables the ghost, moves it to player and transfers controls back to normal body
        {
            Ghost.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
            Ghost.transform.position = Player.transform.position;
            CameraController.Instance.SetFollowTarget(Player.transform);
            AudioManager.Instance.ChangePitch("Music");
            AudioManager.Instance.Play("GhostOff");
            playerAnim.SetBool("GhostMode", false);
        }
        _ghostMode = !_ghostMode;
    }


    void Update()
    {
        if (_ghostMode == true)
        {
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
