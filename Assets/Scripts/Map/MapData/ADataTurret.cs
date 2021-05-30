using GreatFilter.Map.MapData.Turrets;
using GreatFilter.Map.MapData.Turrets.HitEffects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GreatFilter.Map.MapData
{
    [InlineEditor]
    public abstract class ADataTurret : SerializedScriptableObject
    {
        [HorizontalGroup("Turret", 80)] [PreviewField(80)] [HideLabel] public Sprite sprite;

    }
}
