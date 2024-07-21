using System;
using UnityEngine;

namespace NoodleEater
{
    public class Enemy : MonoBehaviour
    {
        private bool _movingRight = true;

        private EnemyConfig _enemyConfig;

        private void Start()
        {
            _enemyConfig = EnemyConfig.Load();
        }

        private void Update()
        {
            MoveAliens();
        }

        private void MoveAliens()
        {
            Vector3 movement = Vector3.right * (_enemyConfig.Speed * Time.deltaTime);
            if (!_movingRight)
            {
                movement = -movement;
            }

            transform.Translate(movement);
            
            if (_movingRight && transform.position.x > _enemyConfig.RightBoundary)
            {
                MoveDown();
                _movingRight = false;
            }

            if (!_movingRight && transform.position.x < _enemyConfig.LeftBoundary)
            {
                MoveDown();
                _movingRight = true;
            }
        }

        private void MoveDown()
        {
            Vector3 moveDown = new Vector3(0, -_enemyConfig.MoveDownAmount, 0);
            transform.position += moveDown;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Bullet bullet = other.GetComponent<Bullet>();

            if (!bullet) return;

            if (!bullet.Owner.TryGetComponent(out Player player)) return;
            
            FindObjectOfType<AudioPlayer>().PlayAudio("enemy.destroyed");
            
            player.AddScore();
            gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}