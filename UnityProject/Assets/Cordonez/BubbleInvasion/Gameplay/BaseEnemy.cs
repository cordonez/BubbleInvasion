using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class BaseEnemy : MonoBehaviour, IEnemy
	{
		public SO_EnemyData EnemyData { get; protected set; }
		public int CurrentHp { get; protected set; }

		protected Rigidbody2D Rigidbody2D;

		public abstract void Init(SO_EnemyData _data, SO_Vector2 _spawnForce);

		private void Awake()
		{
			Rigidbody2D = GetComponent<Rigidbody2D>();
		}

		public void BulletHit()
		{
			CurrentHp--;
			if (CurrentHp == 0)
			{
				Die();
			}
		}

		public void Die()
		{
			foreach (GameObject prefab in EnemyData.Value.OnDestroyPrefabs)
			{
				Instantiate(prefab, transform.position, Quaternion.identity);
			}

			foreach (SO_EnemySpawnData enemySpawnData in EnemyData.Value.OnDestroyEnemies)
			{
				foreach (SO_Vector2 spawnForce in enemySpawnData.Value.SpawnForces)
				{
					GameObject enemyinstanced = Instantiate(enemySpawnData.Value.EnemyData.Value.Prefab, transform.position, Quaternion.identity);
					enemyinstanced.GetComponent<IEnemy>().Init(enemySpawnData.Value.EnemyData, spawnForce);
				}
			}

			Destroy(gameObject);
		}
	}
}