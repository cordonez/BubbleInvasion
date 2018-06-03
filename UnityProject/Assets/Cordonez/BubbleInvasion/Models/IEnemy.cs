﻿using Cordonez.Modules.CustomScriptableObjects.Core.Variables;

namespace Cordonez.BubbleInvasion.Models
{
	public interface IEnemy
	{
		SO_EnemyData EnemyData { get; }

		void Init(SO_EnemyData _data, SO_Vector2 _spawnForce);
		void BulletHit();
		void Die();
	}
}