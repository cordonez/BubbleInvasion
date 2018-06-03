using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class EnemyCheck : MonoBehaviour
	{
		public SOEvent_void ForcePlayerJump;

		private void OnTriggerEnter2D(Collider2D _other)
		{
			IEnemy enemy = _other.GetComponent<IEnemy>();
			if (enemy != null)
			{
				enemy.Die();
				ForcePlayerJump.Invoke();
			}
		}
	}
}