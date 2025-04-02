using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CucaDataSO", menuName = "ScriptableObjects/CucaDataSO", order = 1)]
public class CucaDataSO : ScriptableObject
{
    public List<ReactionSprite> reactionsSprite = new();
}

[Serializable]
public class ReactionSprite
{
    public CucaReaction cucaReaction;
    public string animName;
}
