using System;
using UnityEngine;

namespace NoodleEater
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private float speed;
        [SerializeField] private GameObject bulletPrefab;

        public Action<int> OnHealthChanged;
        public Action<int> OnScoreUpdated;

        public int Score { get; set; }

        private void Start()
        {
            OnHealthChanged?.Invoke(health);
            OnScoreUpdated?.Invoke(Score);
        }

        private void Update()
        {
            Move();

            Shoot();
        }

        private void Move()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * (speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * (speed * Time.deltaTime));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Bullet bullet = other.GetComponent<Bullet>();

            if (!bullet) return;

            if (!bullet.Owner.TryGetComponent(out Enemy enemy)) return;
            
            health--;
            Destroy(other.gameObject);
            OnHealthChanged?.Invoke(health);
        }

        private void Shoot()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            Vector3 shootingPoint = transform.position;
            shootingPoint.y += .5f;
            GameObject bulletGo = Instantiate(bulletPrefab, shootingPoint, Quaternion.identity);
            bulletGo.GetComponent<Bullet>().Initialize(transform, Vector3.up);
        }

        public void AddScore()
        {
            Score += 10;
            
            OnScoreUpdated?.Invoke(Score);
        }
    }
}
