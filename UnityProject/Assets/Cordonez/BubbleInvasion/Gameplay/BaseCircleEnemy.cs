using Cordonez.BubbleInvasion.DataModels;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class BaseCircleEnemy : BaseEnemy
	{
		public override void Init(SO_EnemyData _data, SO_Vector2 _spawnForce)
		{
			EnemyData = _data;
			CurrentHp = _data.Value.Hp;
			transform.localScale = new Vector3(_data.Value.Size, _data.Value.Size, 1);
			Rigidbody2D.gravityScale = _data.Value.GravityScale;
			Rigidbody2D.AddForce(_spawnForce.Value, ForceMode2D.Force);
		}
	}
}