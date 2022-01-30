using UnityEngine;

public class GameManagerAction : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    public void NextScene()
    {
        gm.NextScene();
    }

    public void Quit()
    {
        gm.Quit();
    }
}
