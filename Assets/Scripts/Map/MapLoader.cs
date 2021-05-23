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
        public GameObject planetPrefab;

        [Button("Reload")]
        public void Reload()
        {
            Cleanup();
            Load();
        }

        private void Cleanup()
        {
            foreach(Transform t in transform)
            {
                if (Application.isPlaying)
                {
                    Destroy(t.gameObject);
                }
                else
                {
                    DestroyImmediate(t.gameObject);
                }
            }
        }
        private void Load()
        {

        }
    }
}