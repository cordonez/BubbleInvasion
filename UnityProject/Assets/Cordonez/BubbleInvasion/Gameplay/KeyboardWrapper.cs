using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class KeyboardWrapper : MonoBehaviour
	{
		public SOEvent_void MoveLeft;
		public SOEvent_void MoveLeftStopped;
		public SOEvent_void MoveRight;
		public SOEvent_void MoveRightStopped;
		public SOEvent_void Shoot;
		public SOEvent_void Jump;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump.Invoke();
			}

			if (Input.GetMouseButtonDown(0))
			{
				Shoot.Invoke();
			}

			if (Input.GetKey(KeyCode.D))
			{
				MoveRight.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.D))
			{
				MoveRightStopped.Invoke();
			}

			if (Input.GetKey(KeyCode.A))
			{
				MoveLeft.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.A))
			{
				MoveLeftStopped.Invoke();
			}
		}
	}
}
