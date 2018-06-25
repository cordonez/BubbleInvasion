namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core;
	using UnityEngine;

	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemySpawnData")]
	public class SO_EnemySpawnData : CustomScriptableObject<EnemySpawnData> { }
}