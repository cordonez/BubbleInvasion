using Cordonez.BubbleInvasion.Models;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Bullet : MonoBehaviour, IBullet
	{
		public SO_BulletData BulletData { get; set; }

		private Rigidbody2D m_rigidbody2D;
		private Collider2D m_collider2D;

		private void Awake()
		{
			m_rigidbody2D = GetComponent<Rigidbody2D>();
			m_collider2D = GetComponent<Collider2D>();
		}

		public void Shoot()
		{
			m_rigidbody2D.velocity = Vector2.up * BulletData.Value.Speed;
		}

		private void OnTriggerEnter2D(Collider2D _other)
		{
			if (_other.GetComponent<IMaxHeight>() != null)
			{
				Destroy(gameObject);
				return;
			}

			IEnemy enemy = _other.GetComponent<IEnemy>();
			if (enemy != null)
			{
				enemy.BulletHit();
				m_collider2D.enabled = false;
				Destroy(gameObject);
			}
		}
	}
}