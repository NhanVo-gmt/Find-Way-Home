using GameFoundation.Scripts.Utilities.Extension;
using UnityEngine;
using UserData.Controller;
using Zenject;

public class EscButton : ButtonBehaviour
{
    [Inject] private LevelManager levelManager;

    private void Start()
    {
        this.GetCurrentContainer().Inject(this);
    }
    

    protected override void OnPlayerPressed()
    {
        base.OnPlayerPressed();
        levelManager.ShowLoseScreen();
    }
}
