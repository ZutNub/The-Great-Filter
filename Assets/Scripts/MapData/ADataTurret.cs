using GreatFilter.MapData.Turrets;
using GreatFilter.MapData.Turrets.HitEffects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreatFilter.MapData
{
    [InlineEditor]
    public abstract class ADataTurret : SerializedScriptableObject
    {
        [HorizontalGroup("Turret", 80)] [PreviewField(80)] [HideLabel] public Sprite sprite;

        [FoldoutGroup("Turret/RightColumn/Hit Effect")][ShowInInspector] public ADataHitEffect hitEffect = new DataDmgEffect(); 

        [VerticalGroup("SharedData")][LabelWidth(50)] public bool isInitial;
        [ShowIf("isInitial")][HorizontalGroup("SharedData/Cost")] [LabelWidth(50)] public int metall,gas,gravium,platin;


        [TableList][VerticalGroup("SharedData")] public List<Upgrades> upgrades;

        [Serializable]
        public struct Upgrades
        {
            public int metall, gas, gravium, platin;
            public ADataTurret output;
        }                  
    }
}

/*
 * TODO:
 * 
 * firerate, 
 * dmg (per hit), 
 * impact behaviour (consume, explode, pierce), 
 * affected by gravity, 
 * max travel range,
 * reflected by shields?,
 * bullet speed,
 * applied hit effects,
 * -> Explosion
 * Projektilanzahl
 */