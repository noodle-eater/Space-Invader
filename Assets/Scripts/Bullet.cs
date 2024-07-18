using System;
using UnityEngine;

namespace NoodleEater
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 3;
        [SerializeField] private Sprite playerBullet;
        [SerializeField] private Sprite enemyBullet;
        
        public Transform Owner { get; private set; }
        public Vector3 Direction { get; private set; }

        public void Initialize(Transform owner, Vector3 direction)
        {
            Owner = owner;
            Direction = direction;

            GetComponent<SpriteRenderer>().sprite = direction == Vector3.up ? playerBullet : enemyBullet;
        }

        private void Update()
        {
            transform.Translate(Direction * (speed * Time.deltaTime));
        }
    }
}