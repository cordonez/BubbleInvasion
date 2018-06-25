namespace Cordonez.BubbleInvasion.DataModels
{
	using System;

	[Serializable]
	public class WeaponParams
	{
		public float FireRatePerSecond;
		public int ReloadTime;
		public int ClipSize;
		public int BulletsToFire;
	}
}