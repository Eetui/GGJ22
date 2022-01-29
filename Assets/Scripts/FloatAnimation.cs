using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    [SerializeField] private float floatingSpeed;
    [SerializeField] private float amplitude;
    private Vector2 ogPos;

    private void Start()
    {
        ogPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(ogPos.x, ogPos.y + Mathf.Sin(Time.time * floatingSpeed) * amplitude);
    }
}
