using System;
using UnityEngine;

namespace GreatFilter.MapData.Turrets.HitEffects
{
    [Serializable]
    public class DataSlowEffect : ADataHitEffect
    {
        [Range(0.01f,0.99f)] public float slowPercentage;
        [Range(0,30)] public float slowDuration;
    }
}