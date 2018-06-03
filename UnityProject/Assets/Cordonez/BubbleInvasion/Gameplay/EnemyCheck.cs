using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class EnemyCheck : MonoBehaviour
	{
		public SO_Layermask EnemyLayermask;
		public SOEvent_void ForcePlayerJump;

		private void OnTriggerEnter2D(Collider2D _other)
		{
			if (EnemyLayermask.ContainsLayer(_other.gameObject.layer))
			{
				IEnemy enemy = _other.GetComponent<IEnemy>();
				enemy.Die();
				ForcePlayerJump.Invoke();
			}
		}
	}
}