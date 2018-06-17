using Cordonez.Modules.CustomScriptableObjects.Core;
using UnityEngine;

namespace Cordonez.BubbleInvasion.DataModels
{
	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemySpawnData")]
	public class SO_EnemySpawnData : CustomScriptableObject<EnemySpawnData> { }
}