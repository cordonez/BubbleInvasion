namespace Cordonez.BubbleInvasion.Gameplay
{
	using DataModels;
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

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