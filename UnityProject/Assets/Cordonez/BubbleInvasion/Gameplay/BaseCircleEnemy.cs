using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class BaseCircleEnemy : BaseEnemy
	{
		public SO_Layermask FloorLayermask;
		public SO_Layermask PlayerLayermask;
		public SOEvent_void PlayerDeath;


		public override void Init(SO_EnemyData _data, SO_Vector2 _spawnForce)
		{
			EnemyData = _data;
			CurrentHp = _data.Value.Hp;
			transform.localScale = new Vector3(_data.Value.Size, _data.Value.Size, 1);
			Rigidbody2D.gravityScale = _data.Value.GravityScale;
			Rigidbody2D.AddForce(_spawnForce.Value, ForceMode2D.Force);
		}

		private void OnCollisionEnter2D(Collision2D _other)
		{
			if (FloorLayermask.ContainsLayer(_other.gameObject.layer))
			{
				Vector2 newVelocity = Rigidbody2D.velocity;
				newVelocity.x = newVelocity.x > 0 ? EnemyData.Value.HorizontalVelocity : -EnemyData.Value.HorizontalVelocity;
				newVelocity.y = EnemyData.Value.JumpForce;
				Rigidbody2D.velocity = newVelocity;
			}

			if (PlayerLayermask.ContainsLayer(_other.gameObject.layer))
			{
				PlayerDeath.Invoke();
			}
		}
	}
}