namespace Cordonez.BubbleInvasion.Models
{
	public interface IBullet
	{
		SO_BulletData BulletData { get; set; }
		void Shoot();
	}
}