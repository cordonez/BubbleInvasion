using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class GroundCheck : MonoBehaviour
	{
		public SO_bool PlayerIsGrounded;

		private void OnTriggerEnter2D(Collider2D _other)
		{
			if (_other.GetComponent<IGround>() != null)
			{
				PlayerIsGrounded.Value = true;
			}
		}

		private void OnTriggerExit2D(Collider2D _other)
		{
			if (_other.GetComponent<IGround>() != null)
			{
				PlayerIsGrounded.Value = false;
			}
		}
	}
}