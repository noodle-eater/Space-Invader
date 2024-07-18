using UnityEngine;

namespace NoodleEater
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;
        private GameHud _gameHud;
        private EnemyManager _enemyManager;
        
        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _gameHud = FindObjectOfType<GameHud>();
            _enemyManager = FindObjectOfType<EnemyManager>();

            if (!_player) return;
            if (!_gameHud) return;
            if (!_enemyManager) return;
            
            _player.OnScoreUpdated += OnWin;
            _player.OnHealthChanged += OnGameOver;

            StartCoroutine(_enemyManager.ShootRoutine());
        }

        private void OnWin(int score)
        {
            _gameHud.SetScore(score);
            
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

            if (enemies.Length > 1) return;
            
            StopCoroutine(_enemyManager.ShootRoutine());
            
            _player.gameObject.SetActive(false);
            
            _gameHud.HideScore();
            _gameHud.SetResult("You Win!\nScore: " + _player.Score);
        }

        private void OnGameOver(int health)
        {
            _gameHud.SetHealth(health < 0 ? 0 : health);
            
            if (health > 0) return;
            
            StopCoroutine(_enemyManager.ShootRoutine());
            
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

            foreach (Enemy enemy in enemies)
            {
                enemy.gameObject.SetActive(false);
            }

            _player.gameObject.SetActive(false);
            
            _gameHud.HideScore();
            _gameHud.SetResult("Game Over!\nScore: " + _player.Score);
        }
    }
}