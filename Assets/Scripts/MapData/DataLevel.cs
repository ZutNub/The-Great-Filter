using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GreatFilter.MapData
{
    [CreateAssetMenu(menuName = "Gamedata/Level")]
    public class DataLevel : SerializedScriptableObject
    {
        [ListDrawerSettings(DraggableItems = false, Expanded = false, ShowPaging = true)]
        [OnValueChanged("UpdateIndices")]  public List<PlanetSetup> planets;

        public struct PlanetSetup
        {
            [HideInInspector] public string name;
            private int planetCount;

            [FoldoutGroup("$name")] [HideLabel] public ADataPlanet planet;
            [FoldoutGroup("$name/Planet Settings")] [HorizontalGroup("$name/Planet Settings/parent")] [LabelWidth(100)] public bool hasParent;
            [ValidateInput("TestParent", "The parent index is invalid")] [HorizontalGroup("$name/Planet Settings/parent")] [ShowIf("hasParent")]  [LabelWidth(100)] public int parent;
            [VerticalGroup("$name/Planet Settings/stats")] [LabelWidth(100)] [Range(100, 1000)] public float distance;
            [VerticalGroup("$name/Planet Settings/stats")] [LabelWidth(100)] [Range(0, 360)] public float startRotation;
            [VerticalGroup("$name/Planet Settings/stats")] [LabelWidth(100)] [Range(0, 360)] public float axisRotation;
            [VerticalGroup("$name/Planet Settings/stats")] [LabelWidth(100)] [Range(0, 360)] public float oribitalRotation;
            [VerticalGroup("$name/Planet Settings/stats")] [LabelWidth(100)] public bool populated;

            [ShowIf("populated")] [HorizontalGroup("$name/Planet Settings/Upgrades", 0.5f)] [LabelWidth(100)] [LabelText("Level Eco")] [PropertyRange(0,"GetRangeEco")] public int levelEco;
            [ShowIf("populated")] [HorizontalGroup("$name/Planet Settings/Upgrades", 0.5f)] [LabelWidth(100)] [LabelText("Level Weapon")] [PropertyRange(0, "GetRangeWeapon")] public int levelWeapon;

            [ValidateInput("TestDictionaryKeys","A key is higher then the maximal turret slots!")][ShowIf("populated")] [VerticalGroup("$name/Planet Settings")] [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.ExpandedFoldout)] public Dictionary<int,ADataTurret> turrets;

            private bool TestDictionaryKeys()
            {
                foreach(int key in turrets.Keys)
                {
                    if( key >= planet.turretSlots)
                    {
                        return false;
                    }
                }
                return true;
            }
            private bool TestParent()
            {
                return parent > -1 && parent < planetCount;
            }
            private int GetRangeEco()
            {
                return 3 - levelWeapon;
            }
            private int GetRangeWeapon()
            {
                return 3 - levelEco;
            }
            //Upgrade level, //turrets

            public PlanetSetup(PlanetSetup old, string name, int planetCount)
            {
                this = old;
                this.name = name;
                this.planetCount = planetCount;
            }
        }

        private void UpdateIndices()
        {
            for(int i=0; i<planets.Count; i++)
            {
                planets[i] = new PlanetSetup(planets[i], "Planet "+i, planets.Count);
            }
        }
    }
}















