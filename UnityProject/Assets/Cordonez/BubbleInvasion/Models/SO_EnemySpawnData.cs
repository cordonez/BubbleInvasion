using Cordonez.Modules.CustomScriptableObjects.Core;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Models
{
	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemySpawnData")]
	public class SO_EnemySpawnData : CustomScriptableObject<EnemySpawnData>
	{
	}
}