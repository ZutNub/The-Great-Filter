using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreatFilter.MapStructure
{
    public enum PlanetResources {None, Metall, Gas, Gravium, Platin}
    [CreateAssetMenu(menuName = "MapStructures/Planet")]
    [Serializable]
    public class StructurePlanet : ScriptableObject
    {
        [HorizontalGroup("PlanetData", 80)]
        [PreviewField(80)] [HideLabel] public Sprite sprite;

        [VerticalGroup("PlanetData/Stats")] [Tooltip("the relative mass of the planet, used for gravitation")] [LabelWidth(70)][Range(100,1000)] public int mass;
        [VerticalGroup("PlanetData/Stats")] [Tooltip("the size of the planet, affects turret slot ammount")] [LabelWidth(70)] [Range(10, 45)] [OnValueChanged("UpdateSize")] public float size;
        [VerticalGroup("PlanetData/Stats")] [ReadOnly] [LabelWidth(70)] public int turretSlots;

        [HorizontalGroup("PlanetData/Stats/Resources", Width = 0.5f)] [LabelText("Resources")] [LabelWidth(70)] public PlanetResources resource_0;
        [HorizontalGroup("PlanetData/Stats/Resources",Width = 0.25f)] [HideLabel] public PlanetResources resource_1;
        [HorizontalGroup("PlanetData/Stats/Resources", Width = 0.25f)] [HideLabel] public PlanetResources resource_2;

        private void UpdateSize()
        {
            turretSlots = (int)((size * 2 * Mathf.PI) / 30f);
        }
    }
}