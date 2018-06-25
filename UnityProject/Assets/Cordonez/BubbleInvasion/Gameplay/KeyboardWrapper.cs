namespace Cordonez.BubbleInvasion.Gameplay
{
	using Modules.CustomScriptableObjects.Core.Events;
	using UnityEngine;

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
				Shoot.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Jump.Invoke();
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				MoveRight.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.RightArrow))
			{
				MoveRightStopped.Invoke();
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				MoveLeft.Invoke();
			}

			if (Input.GetKeyUp(KeyCode.LeftArrow))
			{
				MoveLeftStopped.Invoke();
			}
		}
	}
}