namespace Cordonez.BubbleInvasion.Models
{
	using DataModels;

	public interface IBullet
	{
		SO_BulletData BulletData { get; set; }
		void Shoot();
	}
}