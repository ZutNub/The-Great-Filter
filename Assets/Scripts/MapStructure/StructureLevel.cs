using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreatFilter.MapStructure
{
    [CreateAssetMenu(menuName = "MapStructures/Level")]
    public class StructureLevel : ScriptableObject
    {
        [ListDrawerSettings(DraggableItems = false, Expanded = false, ShowPaging = true)]
        public List<PlanetSetup> planets;



        [Serializable]
        public struct PlanetSetup
        {
            [InlineEditor] [HideLabel] public StructurePlanet planet;

            [VerticalGroup("PlanetSetup")] [LabelWidth(100)] [Range(100, 1000)] public float distance;
            [VerticalGroup("PlanetSetup")] [LabelWidth(100)] [Range(0, 360)] public float startRotation;
            [VerticalGroup("PlanetSetup")] [LabelWidth(100)] [Range(0, 360)] public float axisRotation;
            [VerticalGroup("PlanetSetup")] [LabelWidth(100)] [Range(0, 360)] public float oribitalRotation;

            [VerticalGroup("PlanetSetup")] [LabelWidth(100)] public bool populated;

            [ShowIf("populated")][HorizontalGroup("PlanetSetup/Upgrades",0.5f)] [LabelWidth(100)] [LabelText("Level Eco")] [PropertyRange(0,"GetRangeEco")] public int levelEco;
            [ShowIf("populated")] [HorizontalGroup("PlanetSetup/Upgrades",0.5f)] [LabelWidth(100)] [LabelText("Level Weapon")] [PropertyRange(0, "GetRangeWeapon")] public int levelWeapon;

            [ShowIf("populated")] public Dictionary<int,int> turrets;

            private int GetRangeEco()
            {
                return 3 - levelWeapon;
            }
            private int GetRangeWeapon()
            {
                return 3 - levelEco;
            }
            //Upgrade level, //turrets
        }
    }
}















