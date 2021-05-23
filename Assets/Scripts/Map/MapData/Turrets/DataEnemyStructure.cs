using Sirenix.OdinInspector;
using UnityEngine;

namespace GreatFilter.Map.MapData.Turrets
{
    public enum EnemyStructureType { Spawner, Waypoint, Decoration}
   
    [CreateAssetMenu(menuName = "Gamedata/Turrets/Enemy")]
    public class DataEnemyStructure : ADataTurret
    {
        [HorizontalGroup("Turret")] [LabelWidth(110)]  public EnemyStructureType structureType;
    }
}