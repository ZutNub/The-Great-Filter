using System;
using System.Collections.Generic;

namespace GreatFilter.MapData.Turrets.HitEffects
{
    public class DataAgregatedHitEffect : ADataHitEffect
    {
        public List<ADataHitEffect> hitEffects = new List<ADataHitEffect>();
    }
}