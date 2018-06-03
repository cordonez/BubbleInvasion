using Cordonez.BubbleInvasion.Models;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(IEnemy), typeof(SpriteRenderer))]
	public class EnemyHpVisualizer : MonoBehaviour
	{
		public Color[] HpColors;

		private IEnemy m_enemy;
		private SpriteRenderer m_sprite;

		private void Awake()
		{
			m_enemy = GetComponent<IEnemy>();
			m_sprite = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			m_sprite.color = HpColors[m_enemy.CurrentHp];
		}
	}
}
