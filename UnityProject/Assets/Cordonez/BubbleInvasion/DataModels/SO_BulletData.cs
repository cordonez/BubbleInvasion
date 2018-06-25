namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core;
	using UnityEngine;

	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_BulletData")]
	public class SO_BulletData : CustomScriptableObject<BulletData>
	{
		public override void ResetToDefault()
		{
			m_runtimeValue.BulletPrefab = m_value.BulletPrefab;
			m_runtimeValue.Speed = m_value.Speed;
		}
	}
}