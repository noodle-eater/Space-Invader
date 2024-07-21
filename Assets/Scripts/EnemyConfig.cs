using UnityEngine;

namespace NoodleEater
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Gameplay/New Enemy Config", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private  float moveDownAmount = 0.5f;
        [SerializeField] private  float leftBoundary = -8f;
        [SerializeField] private  float rightBoundary = 8f;

        public float Speed => speed;

        public float MoveDownAmount => moveDownAmount;

        public float LeftBoundary => leftBoundary;

        public float RightBoundary => rightBoundary;

        public static EnemyConfig Load() => Resources.Load<EnemyConfig>("EnemyConfig");
    }
}