namespace Cordonez.BubbleInvasion.Gameplay
{
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

	[RequireComponent(typeof(BoxCollider2D))]
	public class GroundCheck : MonoBehaviour
	{
		public SO_Layermask GroundLayermask;
		public SO_bool PlayerIsGrounded;

		private void OnTriggerEnter2D(Collider2D _other)
		{
			if (GroundLayermask.ContainsLayer(_other.gameObject.layer))
			{
				PlayerIsGrounded.Value = true;
			}
		}

		private void OnTriggerExit2D(Collider2D _other)
		{
			if (GroundLayermask.ContainsLayer(_other.gameObject.layer))
			{
				PlayerIsGrounded.Value = false;
			}
		}
	}
}