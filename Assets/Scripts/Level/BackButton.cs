using System.Collections.Generic;
using UnityEngine;

public class BackButton : ButtonBehaviour
{
    [Header("Back Button")]
    [SerializeField] private List<GameObject> walls;
    
    protected override void OnPlayerPressed()
    {
        base.OnPlayerPressed();

        foreach (var wall in walls)
        {
            wall.SetActive(false);
        }
    }

    protected override void OnPlayerUnpressed()
    {
        
    }
}