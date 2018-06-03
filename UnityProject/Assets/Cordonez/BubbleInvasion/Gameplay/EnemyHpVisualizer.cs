using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(BaseEnemy), typeof(SpriteRenderer))]
	public class EnemyHpVisualizer : MonoBehaviour
	{
		public Color[] HpColors;

		private BaseEnemy m_baseEnemy;
		private SpriteRenderer m_sprite;

		private void Awake()
		{
			m_baseEnemy = GetComponent<BaseEnemy>();
			m_sprite = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			m_sprite.color = HpColors[m_baseEnemy.CurrentHp];
		}
	}
}
