using System.Collections;
using Cordonez.BubbleInvasion.DataModels;
using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
    public class EnemyUfo : BaseEnemy
    {
        public override void Init(SO_EnemyData _data, SO_Vector2 _spawnForce)
        {
            EnemyData = _data;
            CurrentHp = _data.Value.Hp;
            transform.localScale = new Vector3(_data.Value.Size, _data.Value.Size, 1);
            Rigidbody2D.velocity = new Vector2((Random.Range(0, 2) == 0 ? 1 : -1) * _data.Value.HorizontalVelocity, 0);
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(EnemyData.Value.SpawnFreq);
                foreach (SO_EnemySpawnData enemySpawnData in EnemyData.Value.Spawn)
                {
                    foreach (SO_Vector2 spawnForce in enemySpawnData.Value.SpawnForces)
                    {
                        GameObject enemyinstanced = Instantiate(enemySpawnData.Value.EnemyData.Value.Prefab, transform.position, Quaternion.identity);
                        enemyinstanced.GetComponent<IEnemy>().Init(enemySpawnData.Value.EnemyData, spawnForce);
                    }
                }
            }
        }
    }
}