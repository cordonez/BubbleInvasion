using Cordonez.Modules.CustomScriptableObjects.Core;
using UnityEngine;

namespace Cordonez.BubbleInvasion.DataModels
{
	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_WeaponParams")]
	public class SO_WeaponParams : CustomScriptableObject<WeaponParams> { }
}