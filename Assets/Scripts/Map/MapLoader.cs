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
                float axisRatio = 1.6f;
                if (p.hasParent)
                {
                    origin = planets[p.parent].transform.position;
                    axisRatio = 1;
                }
                List<Vector3> orbit = OrbitCalculator.CalculateEllipse(origin, axisRatio * p.distance, p.distance, 0, 0, Mathf.Deg2Rad * 1);
                planetObject.transform.position = orbit[(int)p.startRotation];
                planetObject.transform.GetChild(0).position = orbit[(int)(p.startRotation+p.axisRotation)%360];

                LineRenderer dottedLine = planetObject.transform.GetChild(0).GetComponent<LineRenderer>();
                List<Vector3> dottedPoints = new List<Vector3>();
                if(p.startRotation + p.axisRotation > 360)
                {
                    dottedPoints.AddRange(orbit.GetRange((int)p.startRotation, orbit.Count- (int)p.startRotation));
                    dottedPoints.AddRange(orbit.GetRange(0, (int)(p.axisRotation - dottedPoints.Count)));
                }
                else
                {
                    dottedPoints.AddRange(orbit.GetRange((int)p.startRotation, (int)p.axisRotation));
                }

                dottedLine.positionCount = dottedPoints.Count;
                dottedLine.SetPositions(dottedPoints.ToArray());
            }
        }
    }
}