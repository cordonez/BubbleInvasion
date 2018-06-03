using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BaseEnemy : MonoBehaviour, IEnemy
	{
		public SO_Layermask FloorLayermask;
		public SO_Layermask PlayerLayermask;
		public SOEvent_void PlayerDeath;

		public SO_EnemyData EnemyData { get; private set; }

		private Rigidbody2D m_rigidbody2D;

		public void Init(SO_EnemyData _data, SO_Vector2 _spawnForce)
		{
			EnemyData = _data;
			transform.localScale = new Vector3(_data.Value.Size, _data.Value.Size, 1);
			m_rigidbody2D.AddForce(_spawnForce.Value, ForceMode2D.Force);
		}

		public void BulletHit()
		{
			Die();
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

		private void Awake()
		{
			m_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void OnCollisionEnter2D(Collision2D _other)
		{
			if (FloorLayermask.ContainsLayer(_other.gameObject.layer))
			{
				Vector2 newVelocity = m_rigidbody2D.velocity;
				newVelocity.x = newVelocity.x > 0 ? EnemyData.Value.Velocity.Value.x : -EnemyData.Value.Velocity.Value.x;
				newVelocity.y = EnemyData.Value.Velocity.Value.y;
				m_rigidbody2D.velocity = newVelocity;
			}

			if (PlayerLayermask.ContainsLayer(_other.gameObject.layer))
			{
				PlayerDeath.Invoke();
			}
		}
	}
}