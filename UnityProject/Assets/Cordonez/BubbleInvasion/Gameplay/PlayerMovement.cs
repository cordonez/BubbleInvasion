namespace Cordonez.BubbleInvasion.Gameplay
{
	using Modules.CustomScriptableObjects.Core.Events;
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerMovement : MonoBehaviour
	{
		public SO_bool PlayerIsGrounded;
		public SO_float MovementSpeed;
		public SO_float JumpForce;

		public SOEvent_void MoveLeft;
		public SOEvent_void MoveLeftStopped;
		public SOEvent_void MoveRight;
		public SOEvent_void MoveRightStopped;
		public SOEvent_void Jump;
		public SOEvent_void ForceJump;

		private Rigidbody2D m_rigidbody2D;

		private void Awake()
		{
			m_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void OnEnable()
		{
			MoveLeft.AddListener(OnMoveLeft);
			MoveLeftStopped.AddListener(OnMoveLeftStopped);
			MoveRight.AddListener(OnMoveRight);
			MoveRightStopped.AddListener(OnMoveRightStopped);
			Jump.AddListener(OnJump);
			ForceJump.AddListener(PlayerJump);
		}

		private void OnMoveRightStopped()
		{
			if (m_rigidbody2D.velocity.x > 0)
			{
				m_rigidbody2D.velocity = new Vector2(0, m_rigidbody2D.velocity.y);
			}
		}

		private void OnMoveLeftStopped()
		{
			if (m_rigidbody2D.velocity.x < 0)
			{
				m_rigidbody2D.velocity = new Vector2(0, m_rigidbody2D.velocity.y);
			}
		}

		private void OnDisable()
		{
			MoveLeft.RemoveListener(OnMoveLeft);
			MoveLeftStopped.RemoveListener(OnMoveLeftStopped);
			MoveRight.RemoveListener(OnMoveRight);
			MoveRightStopped.RemoveListener(OnMoveRightStopped);
			Jump.RemoveListener(OnJump);
			ForceJump.RemoveListener(PlayerJump);
		}

		private void OnMoveRight()
		{
			m_rigidbody2D.velocity = new Vector2(MovementSpeed, m_rigidbody2D.velocity.y);
		}

		private void OnMoveLeft()
		{
			m_rigidbody2D.velocity = new Vector2(-MovementSpeed, m_rigidbody2D.velocity.y);
		}

		private void OnJump()
		{
			if (PlayerIsGrounded)
			{
				PlayerJump();
			}
		}

		private void PlayerJump()
		{
			m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, JumpForce);
		}
	}
}