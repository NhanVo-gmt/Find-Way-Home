namespace UserData.Model
{
    using System;
    using System.Collections.Generic;
    using Blueprints;
    using DataManager.LocalData;
    using DataManager.UserData;
    using Newtonsoft.Json;

    public  class UserProfile : IUserData, ILocalData
    {
        public string                       CurrentLevelId { get; set; } = "";
        public Dictionary<string, LevelLog> levelLogs;
    }
    
    public class LevelLog
    {
        public string Id;
        public State  LevelState;

        [JsonIgnore] public LevelRecord LevelRecord;
        [JsonIgnore] public Action      OnCompleted;
    }


    public enum State
    {
        InActive,
        Active,
        Complete
    }
}