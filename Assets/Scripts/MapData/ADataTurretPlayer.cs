using GreatFilter.MapData.Turrets;
using GreatFilter.MapData.Turrets.HitEffects;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreatFilter.MapData
{
    public abstract class ADataTurretPlayer : ADataTurret
    {
        [FoldoutGroup("Turret/RightColumn/Hit Effect")] [ShowInInspector] public ADataHitEffect hitEffect = new DataDmgEffect();

        [VerticalGroup("SharedData")] [LabelWidth(50)] public bool isInitial;
        [ShowIf("isInitial")] [HorizontalGroup("SharedData/Cost")] [LabelWidth(50)] public int metall, gas, gravium, platin;


        [TableList] [VerticalGroup("SharedData")] public List<Upgrades> upgrades;

        [Serializable]
        public struct Upgrades
        {
            public int metall, gas, gravium, platin;
            public ADataTurret output;
        }
    }
}

