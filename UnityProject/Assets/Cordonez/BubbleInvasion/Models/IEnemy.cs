namespace Cordonez.BubbleInvasion.Models
{
	public interface IEnemy
	{
		SO_EnemyData EnemyData { get; }

		void Init(SO_EnemyData _data);
		void BulletHit();
		void Die();
	}
}