using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
using GameFoundation.Scripts.Utilities.Extension;
using UnityEngine;
using Zenject;

public class EscButton : MonoBehaviour
{
    [Inject] private IScreenManager screenManager;

    private void Start()
    {
        this.GetCurrentContainer().Inject(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>())
        {
            this.screenManager.OpenScreen<GameLosePresenter>();
        }
    }
    
}
