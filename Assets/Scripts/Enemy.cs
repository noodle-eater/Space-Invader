using System;
using UnityEngine;

namespace NoodleEater
{
    public class Enemy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Bullet bullet = other.GetComponent<Bullet>();

            if (!bullet) return;

            if (!bullet.Owner.TryGetComponent(out Player player)) return;
            
            player.AddScore();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}