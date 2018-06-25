namespace Cordonez.BubbleInvasion.Models
{
	using DataModels;
	using Modules.CustomScriptableObjects.Core.Variables;

	public interface IEnemy
	{
		SO_EnemyData EnemyData { get; }
		int CurrentHp { get; }

		void Init(SO_EnemyData _data, SO_Vector2 _spawnForce);
		void BulletHit();
		void Die();
	}
}