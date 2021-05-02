using System;
using UnityEngine;

namespace GreatFilter.MapData.Turrets.HitEffects
{
    [Serializable]
    public class DataIgniteEffect : ADataHitEffect
    {
        [Range(0,10)]public float igniteDuration;
        [Range(0.1f, 10)] public float tickRate;
        [Range(1, 100)] public float tickDmg;
    }
}