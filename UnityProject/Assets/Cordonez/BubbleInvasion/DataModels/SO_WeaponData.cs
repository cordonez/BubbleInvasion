using Cordonez.Modules.CustomScriptableObjects.Core;
using UnityEngine;

namespace Cordonez.BubbleInvasion.DataModels
{
	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_WeaponData")]
	public class SO_WeaponData : CustomScriptableObject<WeaponData> { }
}