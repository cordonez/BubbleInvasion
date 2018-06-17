using Cordonez.Modules.CustomScriptableObjects.Core;
using UnityEngine;

namespace Cordonez.BubbleInvasion.DataModels
{
	[CreateAssetMenu(menuName = MenuPath.CUSTOM_VARIABLES + "SO_EnemyData")]
	public class SO_EnemyData : CustomScriptableObject<EnemyData> { }
}