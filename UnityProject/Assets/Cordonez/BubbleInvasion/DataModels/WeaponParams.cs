using System;

namespace Cordonez.BubbleInvasion.DataModels
{
	[Serializable]
	public class WeaponParams
	{
		public float FireRatePerSecond;
		public int ReloadTime;
		public int ClipSize;
		public int BulletsToFire;
	}
}