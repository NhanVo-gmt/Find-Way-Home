namespace UIFeatures.LoadingScene
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blueprints;
    using Cysharp.Threading.Tasks;
    using DataManager.MasterData;
    using DG.Tweening;
    using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
    using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
    using GameFoundation.Scripts.Utilities.ObjectPool;
    using GameFoundationBridge;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using UserData.Controller;
    using Zenject;
    
    public class SelectLevelScreenView : BaseView
    {
        public Button settingButton;
        
        [Header("Body")]
        public SelectLevelItemView selectLevelItemViewPrefab;
    }

    [ScreenInfo(nameof(SelectLevelScreenView))]
    public class SelectLevelScreenPresenter : BaseScreenPresenter<SelectLevelScreenView>
    {
        private readonly LevelManager    levelManager;
        private readonly DiContainer     diContainer;
        private readonly IScreenManager  screenManager;

        private List<SelectLevelItemView> selectLevelItemViews = new();
        
        private readonly ObjectPoolManager objectPoolManager;

        public SelectLevelScreenPresenter(SignalBus signalBus, LevelManager levelManager, 
                                          DiContainer diContainer, IScreenManager screenManager, ObjectPoolManager objectPoolManager) : base(signalBus)
        {
            this.levelManager      = levelManager;
            this.diContainer       = diContainer;
            this.screenManager     = screenManager;
            this.objectPoolManager = objectPoolManager;
        }

        protected override void OnViewReady()
        {
            base.OnViewReady();
            
            this.OpenViewAsync().Forget();
        }

        public override async UniTask BindData()
        {
            this.View.settingButton.onClick.AddListener(OpenSettingScreen);
            
            await PopulateLevelList();
        }

        void OpenSettingScreen()
        {
            this.screenManager.OpenScreen<GameSettingPopupPresenter>();
        }

        async Task PopulateLevelList()
        {
            List<LevelRecord> levelRecords = this.levelManager.GetAllLevels();
            this.View.selectLevelItemViewPrefab.BindData(levelRecords.FirstOrDefault());
        }

        public override void Dispose()
        {
            base.Dispose();
            
            this.selectLevelItemViews.ForEach(item => item.Dispose());
            this.selectLevelItemViews.Clear();
            
            this.View.settingButton.onClick.RemoveListener(OpenSettingScreen);
        }
    }
}