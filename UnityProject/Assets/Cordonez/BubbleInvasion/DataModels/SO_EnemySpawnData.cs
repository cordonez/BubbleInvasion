namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core;
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemySpawnData")]
	public class SO_EnemySpawnData : CustomScriptableObject<EnemySpawnData>
	{
		public override void ResetToDefault()
		{
			m_runtimeValue.EnemyData = m_value.EnemyData;
			m_runtimeValue.SpawnForces = (SO_Vector2[]) m_value.SpawnForces.Clone();
		}
	}
}