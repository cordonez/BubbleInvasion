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

		public void Init(SO_EnemyData _data)
		{
			EnemyData = _data;
			transform.localScale = new Vector3(_data.Value.Size, _data.Value.Size, 1);
			m_rigidbody2D.AddForce(EnemyData.Value.SpawnForce[0].Value, ForceMode2D.Force);
		}

		public void BulletHit()
		{
			Die();
		}

		private void Die()
		{
			foreach (GameObject prefab in EnemyData.Value.OnDestroyPrefabs)
			{
				Instantiate(prefab, transform.position, Quaternion.identity);
			}

			foreach (SO_EnemyData enemy in EnemyData.Value.OnDestroyEnemies)
			{
				GameObject enemyinstanced = Instantiate(enemy.Value.Prefab, transform.position, Quaternion.identity);
				enemyinstanced.GetComponent<IEnemy>().Init(enemy);
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
				newVelocity.x = newVelocity.x > 0 ? EnemyData.Value.Velocity.x : -EnemyData.Value.Velocity.x;
				newVelocity.y = EnemyData.Value.Velocity.y;
				m_rigidbody2D.velocity = newVelocity;
			}

			if (PlayerLayermask.ContainsLayer(_other.gameObject.layer))
			{
				PlayerDeath.Invoke();
			}
		}
	}
}