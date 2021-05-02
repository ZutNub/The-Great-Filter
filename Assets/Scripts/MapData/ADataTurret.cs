using GreatFilter.MapData.Turrets;
using GreatFilter.MapData.Turrets.HitEffects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GreatFilter.MapData
{
    [InlineEditor]
    public abstract class ADataTurret : SerializedScriptableObject
    {
        [HorizontalGroup("Turret", 80)] [PreviewField(80)] [HideLabel] public Sprite sprite;

    }
}
