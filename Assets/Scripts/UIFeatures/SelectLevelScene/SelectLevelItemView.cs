using System.Collections.Generic;
using System.Linq;
using Blueprints;
using GameFoundation.Scripts.Utilities.ObjectPool;
using UnityEngine;
using Zenject;


public class SelectLevelItemView : MonoBehaviour
{
    public SelectStageView stageViewPrefab;
    public RectTransform stageViewContent;
    
    #region Inject

    [Inject] private readonly ObjectPoolManager objectPoolManager;
    [Inject] private readonly DiContainer       diContainer;

    #endregion
    
    private List<SelectStageView> stageViews = new();
    private LevelRecord           levelRecord;
    
    public void BindData(LevelRecord levelRecord)
    {
        this.levelRecord = levelRecord;
        
        InitializeStage();
    }

    void InitializeStage()
    {
        this.stageViewPrefab.gameObject.SetActive(false);
        
        this.stageViews = this.levelRecord.StageRecords.Select(record =>
        {
            var instance = objectPoolManager.Spawn(this.stageViewPrefab, this.stageViewContent);
            var position = instance.transform.localPosition;
            position.z                       = 0;
            instance.transform.localPosition = position;
            instance.transform.localScale    = Vector3.one;
            diContainer.Inject(instance);
            instance.BindData(this.levelRecord, record.StageIndex);
            
            instance.gameObject.SetActive(true);
            return instance;
        }).ToList();
    }

    public void Dispose()
    {
        this.stageViews.ForEach(view => { view.Recycle(); });
        this.stageViews.Clear();
    }
}

