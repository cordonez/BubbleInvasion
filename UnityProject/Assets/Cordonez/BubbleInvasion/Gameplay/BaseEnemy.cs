namespace Cordonez.BubbleInvasion.Gameplay
{
	using DataModels;
	using Models;
	using Modules.CustomScriptableObjects.Core.Events;
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
	public abstract class BaseEnemy : MonoBehaviour, IEnemy
	{
		public SO_EnemyData EnemyData { get; protected set; }
		public int CurrentHp { get; protected set; }

		public SO_Layermask FloorLayermask;
		public SO_Layermask WallLayermask;
		public SO_Layermask PlayerLayermask;
		public SOEvent_void PlayerDeath;
		public SOEvent_void ForcePlayerJump;

		protected Rigidbody2D Rigidbody2D;

		public abstract void Init(SO_EnemyData _data, SO_Vector2 _spawnForce);

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

		private void OnTriggerEnter2D(Collider2D _other)
		{
			if (FloorLayermask.ContainsLayer(_other.gameObject.layer))
			{
				Vector2 newVelocity = Rigidbody2D.velocity;
				newVelocity.x = newVelocity.x > 0 ? EnemyData.Value.HorizontalVelocity : -EnemyData.Value.HorizontalVelocity;
				newVelocity.y = EnemyData.Value.JumpForce;
				Rigidbody2D.velocity = newVelocity;
			}

			if (WallLayermask.ContainsLayer(_other.gameObject.layer))
			{
				Rigidbody2D.velocity = new Vector2(-Rigidbody2D.velocity.x, Rigidbody2D.velocity.y);
			}

			if (PlayerLayermask.ContainsLayer(_other.gameObject.layer))
			{
				if (_other.transform.position.y > transform.position.y)
				{
					BulletHit();
					ForcePlayerJump.Invoke();
				}
				else
				{
					PlayerDeath.Invoke();
				}
			}
		}

		private void Awake()
		{
			Rigidbody2D = GetComponent<Rigidbody2D>();
		}
	}
}