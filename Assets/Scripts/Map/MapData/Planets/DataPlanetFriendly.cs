using Sirenix.OdinInspector;
using UnityEngine;

namespace GreatFilter.Map.MapData.Planets
{
    [CreateAssetMenu(menuName = "Gamedata/Planets/Friendly")]
    public class DataPlanetFriendly : ADataPlanet
    {
        [HorizontalGroup("PlanetData/Stats/Resources", Width = 0.5f)] [LabelText("Resources")] [LabelWidth(70)] public PlanetResources resource_0;
        [HorizontalGroup("PlanetData/Stats/Resources", Width = 0.25f)] [HideLabel] public PlanetResources resource_1;
        [HorizontalGroup("PlanetData/Stats/Resources", Width = 0.25f)] [HideLabel] public PlanetResources resource_2;
    }
}