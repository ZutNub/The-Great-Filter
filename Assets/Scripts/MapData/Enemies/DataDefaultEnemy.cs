using Sirenix.OdinInspector;
using UnityEngine;

namespace GreatFilter.MapData.Enemies
{
    public class DataDefaultEnemy : ADataEnemy
    {
        [HorizontalGroup("Enemy", 80)] [PreviewField(80)] [HideLabel] public Sprite sprite;
        [VerticalGroup("Enemy/RightColumn")] [LabelWidth(110)] [Range(1, 10)] public float speed;
        [VerticalGroup("Enemy/RightColumn")] [LabelWidth(110)] [Range(10, 1000)] public int hp;
        [VerticalGroup("Enemy/RightColumn")] [LabelWidth(110)] public bool reflectiv;
        [VerticalGroup("Enemy/RightColumn")] [LabelWidth(110)] [Range(0, 100)] public float armor;

    }
}