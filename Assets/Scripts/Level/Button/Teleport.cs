using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport  teleport;
    [SerializeField] private Transform appearPos;

    public Vector2 GetAppearPosition()
    {
        return appearPos;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
        {
            other.transform.position = teleport.GetAppearPosition();
        }
    }
}