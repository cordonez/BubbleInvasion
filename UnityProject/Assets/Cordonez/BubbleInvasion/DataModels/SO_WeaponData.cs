namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core;
	using UnityEngine;

	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_WeaponData")]
	public class SO_WeaponData : CustomScriptableObject<WeaponData>
	{
		public override void ResetToDefault()
		{
			m_runtimeValue.WeaponParams = m_value.WeaponParams;
			m_runtimeValue.BulletData = m_value.BulletData;
		}
	}
}