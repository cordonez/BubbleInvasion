namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core;
	using UnityEngine;

	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemyData")]
	public class SO_EnemyData : CustomScriptableObject<EnemyData>
	{
		public override void ResetToDefault()
		{
			m_runtimeValue.Prefab = m_value.Prefab;
			m_runtimeValue.Hp = m_value.Hp;
			m_runtimeValue.Size = m_value.Size;
			m_runtimeValue.HorizontalVelocity = m_value.HorizontalVelocity;
			m_runtimeValue.JumpForce = m_value.JumpForce;
			m_runtimeValue.GravityScale = m_value.GravityScale;
			m_runtimeValue.SpawnFreq = m_value.SpawnFreq;
			m_runtimeValue.Spawn = (SO_EnemySpawnData[]) m_value.Spawn.Clone();
			m_runtimeValue.OnDestroyEnemies = (SO_EnemySpawnData[]) m_value.OnDestroyEnemies.Clone();
			m_runtimeValue.OnDestroyPrefabs = (GameObject[]) m_value.OnDestroyPrefabs.Clone();
		}
	}
}