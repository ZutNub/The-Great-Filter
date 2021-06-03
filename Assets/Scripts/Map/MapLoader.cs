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
        public GameObject turretPreviewObject;
        public bool reloadInFixedUpdate;

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
                
                //scale
                planetObject.transform.localScale = new Vector3(p.planet.size, p.planet.size, p.planet.size);

                //position & orbit
                List<Vector3> orbit = OrbitCalculator.CalculateEllipse(origin, axisRatio * p.distance, p.distance, 0, 0, Mathf.Deg2Rad * 1);
                planetObject.transform.position = orbit[(int)p.startRotation];
                planetObject.transform.GetChild(0).position = orbit[(int)(p.startRotation+p.oribitalRotation) %360];

                //rotation
                planetObject.transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, p.axisRotation);

                //dottet line
                LineRenderer dottedLine = planetObject.transform.GetChild(0).GetComponent<LineRenderer>();
                List<Vector3> dottedPoints = new List<Vector3>();
                if(p.startRotation + p.oribitalRotation > 360)
                {
                    dottedPoints.AddRange(orbit.GetRange((int)p.startRotation, orbit.Count- (int)p.startRotation));
                    dottedPoints.AddRange(orbit.GetRange(0, (int)(p.oribitalRotation - dottedPoints.Count)));
                }
                else
                {
                    dottedPoints.AddRange(orbit.GetRange((int)p.startRotation, (int)p.oribitalRotation));
                }
                dottedLine.positionCount = dottedPoints.Count;
                dottedLine.SetPositions(dottedPoints.ToArray());

                //turrets
                if (p.turrets != null)
                {
                    foreach (var t in p.turrets)
                    {
                        int index = t.Key;
                        ADataTurret turret = t.Value;

                        //turret preview on main planet
                        GameObject turretObject = GameObject.Instantiate(turretPreviewObject, planetObject.transform);
                        turretObject.transform.localRotation = Quaternion.Euler(0, 0, 360 * (index / (float)p.planet.GetMaxTurretSlots()));
                        turretObject.transform.GetChild(0).localScale = new Vector3(1f / p.planet.size, 1f / p.planet.size, 1f / p.planet.size);
                        turretObject.transform.GetChild(0).localPosition = new Vector3(0,0.35f+0.5f/ p.planet.size, 0);

                        //turret preview on preview planet
                        GameObject turretObjectPreview = GameObject.Instantiate(turretPreviewObject, planetObject.transform.GetChild(0));
                        turretObjectPreview.transform.localRotation = Quaternion.Euler(0, 0, 360 * (index / (float)p.planet.GetMaxTurretSlots()));
                        turretObjectPreview.transform.GetChild(0).localScale = new Vector3(1f / p.planet.size, 1f / p.planet.size, 1f / p.planet.size);
                        turretObjectPreview.transform.GetChild(0).localPosition = new Vector3(0, 0.35f + 0.5f / p.planet.size, 0);
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if(reloadInFixedUpdate)
                Reload();
        }
    }
}