namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core;
	using UnityEngine;

	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_WeaponParams")]
	public class SO_WeaponParams : CustomScriptableObject<WeaponParams>
	{
		public override void ResetToDefault()
		{
			m_runtimeValue.FireRatePerSecond = m_value.FireRatePerSecond;
			m_runtimeValue.ReloadTime = m_value.ReloadTime;
			m_runtimeValue.ClipSize = m_value.ClipSize;
			m_runtimeValue.BulletsToFire = m_value.BulletsToFire;
		}
	}
}