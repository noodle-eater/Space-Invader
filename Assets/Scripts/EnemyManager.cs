using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NoodleEater
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float shootInterval = 1f;

        public IEnumerator ShootRoutine()
        {
            yield return new WaitForSeconds(2f);
            
            while (true)
            {
                Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

                if (enemies == null || enemies.Length == 0) yield break;

                Enemy enemy = enemies[Random.Range(0, enemies.Length)];

                if (!enemy)
                {
                    yield return null;
                    continue;  // Skip to the next iteration if the selected enemy is null
                }

                Vector3 shootPoint = enemy.transform.position;
                shootPoint.y -= .5f;
                GameObject bulletGo = Instantiate(bulletPrefab, shootPoint, Quaternion.identity);
                bulletGo.GetComponent<Bullet>().Initialize(enemy.transform, Vector3.down);
                
                yield return new WaitForSeconds(shootInterval);
            }
        }
    }
}