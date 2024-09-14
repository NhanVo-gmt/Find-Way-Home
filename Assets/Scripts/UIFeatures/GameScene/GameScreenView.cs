using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
using GameFoundationBridge;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameScreenView : BaseView
{
    public Button backButton;
    public Button settingButton;
}

[ScreenInfo(nameof(GameScreenView))]
public class GameScreenPresenter : BaseScreenPresenter<GameScreenView>
{
    private readonly GameSceneDirector gameSceneDirector;
    private readonly IScreenManager    screenManager;
    
    
    public GameScreenPresenter(SignalBus signalBus, GameSceneDirector gameSceneDirector, IScreenManager screenManager) : base(signalBus)
    {
        this.gameSceneDirector = gameSceneDirector;
        this.screenManager     = screenManager;
    }

    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.OpenViewAsync().Forget();
    }

    public override UniTask BindData()
    {
        this.View.backButton.onClick.AddListener(GoBackLevelScene);
        this.View.settingButton.onClick.AddListener(OpenSettingScreen);
        return UniTask.CompletedTask;
    }

    public override void Dispose()
    {
        this.View.backButton.onClick.RemoveAllListeners();
        this.View.settingButton.onClick.RemoveAllListeners();
    }

    void GoBackLevelScene()
    {
        gameSceneDirector.LoadLevelSelectScene().Forget();
    }

    void OpenSettingScreen()
    {
        this.screenManager.OpenScreen<GameSettingPopupPresenter>();
    }
}
