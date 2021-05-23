using Sirenix.OdinInspector;
using UnityEngine;

//affected by gravity
namespace GreatFilter.Map.MapData.Turrets
{
    [CreateAssetMenu(menuName = "Gamedata/Turrets/Projectile")]
    public class DataTurretProjectile : ADataTurretPlayer
    {
        [VerticalGroup("Turret/RightColumn")]
        [FoldoutGroup("Turret/RightColumn/Projectile Settings")]
        [VerticalGroup("Turret/RightColumn/Projectile Settings/Data")] [LabelWidth(110)] [Range(0.1f,10)] public float fireRate;
        [VerticalGroup("Turret/RightColumn/Projectile Settings/Data")] [LabelWidth(110)] [Range(1, 10)] public int projectileAmmount;
        [VerticalGroup("Turret/RightColumn/Projectile Settings/Data")] [LabelWidth(110)] [Range(0, 10)] public float variance;
        [VerticalGroup("Turret/RightColumn/Projectile Settings/Data")] [LabelWidth(110)] [Range(10, 100)] public int projectileSpeed;

        [FoldoutGroup("Turret/RightColumn/Explosion Settings")] [LabelWidth(110)] public bool isExplosive ;
        [ShowIf("isExplosive")][VerticalGroup("Turret/RightColumn/Explosion Settings/Data")] [LabelWidth(110)] [Range(0.1f, 10)] public float explosionRange;
        [ShowIf("isExplosive")] [VerticalGroup("Turret/RightColumn/Explosion Settings/Data")] [LabelWidth(110)] [Range(0.2f, 2)] public float explosionDuration;
    }
}
