using Sirenix.OdinInspector;
using UnityEngine;

namespace GreatFilter.MapData
{
    public enum PlanetResources {None, Metall, Gas, Gravium, Platin}
    [InlineEditor]
    public abstract class ADataPlanet : ScriptableObject
    {
        [HorizontalGroup("PlanetData", 80)]
        [PreviewField(80)] [HideLabel] public Sprite sprite;

        [VerticalGroup("PlanetData/Stats")] [Tooltip("the relative mass of the planet, used for gravitation")] [LabelWidth(70)][Range(100,1000)] public int mass;
        [VerticalGroup("PlanetData/Stats")] [Tooltip("the size of the planet, affects turret slot ammount")] [LabelWidth(70)] [Range(10, 45)] [OnValueChanged("UpdateSize")] public float size;
        [VerticalGroup("PlanetData/Stats")] [ReadOnly] [LabelWidth(70)] public int turretSlots;

        private void UpdateSize()
        {
            turretSlots = (int)((size * 2 * Mathf.PI) / 30f);
        }
    }
}