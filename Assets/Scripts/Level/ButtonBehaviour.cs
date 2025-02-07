using GameFoundation.Scripts.Utilities.Extension;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public Sprite normal;
    public Sprite pressed;
    
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer        = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normal;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
        {
            OnPlayerPressed();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
        {
            OnPlayerUnpressed();
        }
    }

    protected virtual void OnPlayerPressed()
    {
        spriteRenderer.sprite = pressed;
    }
    
    protected virtual void OnPlayerUnpressed()
    {
        spriteRenderer.sprite = normal;
    }
}