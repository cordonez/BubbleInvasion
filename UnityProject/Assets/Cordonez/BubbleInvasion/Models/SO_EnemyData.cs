using Cordonez.Modules.CustomScriptableObjects.Core;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Models
{
	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemyData")]
	public class SO_EnemyData : CustomScriptableObject<EnemyData>
	{
	}
}