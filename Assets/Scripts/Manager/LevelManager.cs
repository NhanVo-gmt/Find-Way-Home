namespace UserData.Controller
{
    using System;
    using System.Collections.Generic;
    using DataManager.MasterData;
    using DataManager.UserData;
    using UserData.Model;
    using System.Linq;
    using Blueprints;
    using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;

    public class LevelManager : BaseDataManager<UserProfile>
    {
        #region Inject

        private readonly LevelBlueprint         levelBlueprint;
        private readonly ScreenManager          screenManager;

        #endregion

        public Action OnUseHint;
        
        public LevelManager(MasterDataManager masterDataManager, LevelBlueprint levelBlueprint, ScreenManager screenManager 
                            ) : base(masterDataManager)
        {
            this.levelBlueprint  = levelBlueprint;
            this.screenManager   = screenManager;
        }

        protected override void OnDataLoaded()
        {
            base.OnDataLoaded();

            if (String.IsNullOrWhiteSpace(this.Data.CurrentLevelId))
            {
                LoadDefaultLevel();
            }

            if (this.Data.levelLogs == null)
            {
                CreateLevelLogSave();
            }
            else
            {
                LoadLevelLogSave();
            }
        }

        void LoadDefaultLevel()
        {
            this.Data.CurrentLevelId = levelBlueprint.FirstOrDefault().Value.Id;
        }
        
        private void CreateLevelLogSave()
        {
            this.Data.levelLogs = new();
            foreach (var level in GetAllLevels())
            {
                this.Data.levelLogs[level.Id] = new()
                {
                    Id            = level.Id,
                    LevelRecord   = level,
                    LevelState    = State.Active,
                };
            }
        }

        private void LoadLevelLogSave()
        {
            foreach (var levelLog in this.Data.levelLogs.Values)
            {
                LevelRecord levelRecord = GetLevelRecord(levelLog.Id);
                levelLog.LevelRecord = levelRecord;
            }
        }

        public List<LevelRecord> GetAllLevels()
        {
            return levelBlueprint.Values.ToList();
        }

        public LevelRecord GetCurrentLevel()
        {
            return levelBlueprint[this.Data.CurrentLevelId];
        }

        public LevelLog GetCurrentLevelLog()
        {
            return this.Data.levelLogs[GetCurrentLevel().Id];
        }

        public LevelRecord GetLevelRecord(string Id)
        {
            return levelBlueprint[Id];
        }

        #region In Game
        
        public void SelectLevel(LevelRecord levelRecord)
        {
            GetCurrentLevelLog().OnCompleted -= ShowCompletedScreen;
                
            this.Data.CurrentLevelId         =  levelRecord.Id;
            GetCurrentLevelLog().OnCompleted += ShowCompletedScreen;
        }

        public void ShowCompletedScreen()
        {
            this.screenManager.OpenScreen<GameCompletePopupPresenter, LevelLog>(GetCurrentLevelLog());
        }

        #endregion
    }
    
}
