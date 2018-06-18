using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(Animator))]
	public class MonkeyAnimatorController : MonoBehaviour
	{
		private Animator m_animator;

		public SOEvent_void MoveLeft;
		public SOEvent_void MoveLeftStopped;
		public SOEvent_void MoveRight;
		public SOEvent_void MoveRightStopped;
		public SOEvent_void Shoot;

		private readonly int m_shoot = Animator.StringToHash("Shoot");
		private readonly int m_move = Animator.StringToHash("Move");

		private Vector3 m_front = new Vector3(0, 180, 0);
		private Vector3 m_right = new Vector3(0, 90, 0);
		private Vector3 m_left = new Vector3(0, -90, 0);

		private void Awake()
		{
			m_animator = GetComponent<Animator>();
		}

		private void OnEnable()
		{
			MoveLeft.AddListener(OnMoveLeft);
			MoveLeftStopped.AddListener(OnMoveLeftStopped);
			MoveRight.AddListener(OnMoveRight);
			MoveRightStopped.AddListener(OnMoveRightStopped);
			Shoot.AddListener(OnShoot);
		}

		private void OnDisable()
		{
			MoveLeft.RemoveListener(OnMoveLeft);
			MoveLeftStopped.RemoveListener(OnMoveLeftStopped);
			MoveRight.RemoveListener(OnMoveRight);
			MoveRightStopped.RemoveListener(OnMoveRightStopped);
			Shoot.RemoveListener(OnShoot);
		}

		private void OnShoot()
		{
			transform.localEulerAngles = m_front;
			m_animator.ResetTrigger(m_shoot);
			m_animator.SetTrigger(m_shoot);
		}

		private void OnMoveRightStopped()
		{
			transform.localEulerAngles = m_front;
			m_animator.SetBool(m_move, false);
		}

		private void OnMoveRight()
		{
			transform.localEulerAngles = m_right;
			m_animator.SetBool(m_move, true);
		}

		private void OnMoveLeftStopped()
		{
			transform.localEulerAngles = m_front;
			m_animator.SetBool(m_move, false);
		}

		private void OnMoveLeft()
		{
			transform.localEulerAngles = m_left;
			m_animator.SetBool(m_move, true);
		}
	}
}