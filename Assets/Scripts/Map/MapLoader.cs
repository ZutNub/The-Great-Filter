using GreatFilter.Map.MapData;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreatFilter.Map
{
    public class MapLoader : MonoBehaviour
    {
        public DataLevel level;
        public GameObject planetPreviewObject;

        [Button("Reload")]
        public void Reload()
        {
            Cleanup();
            Load();
        }

        private void Cleanup()
        {
            if (Application.isPlaying)
            {
                foreach (Transform t in transform)
                {
                    Destroy(t.gameObject);
                }
            }
            else
            {
                while(transform.childCount > 0)
                {
                    DestroyImmediate(transform.GetChild(0).gameObject);
                }
            }              
        }
        private void Load()
        {
            List<GameObject> planets = new List<GameObject>();
            for(int i=0; i < level.planets.Count; i++)
            {
                DataLevel.PlanetSetup p = level.planets[i];

                GameObject planetObject = GameObject.Instantiate(planetPreviewObject, transform);
                planets.Add(planetObject);

                planetObject.name = "Planet " + i;

                Vector3 origin = Vector3.zero;
                if (p.hasParent)
                {
                    origin = planets[p.parent].transform.position;
                }
                OrbitCalculator.e(,)
            }
        }
    }
}