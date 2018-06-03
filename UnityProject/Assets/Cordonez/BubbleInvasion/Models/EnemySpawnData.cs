using Cordonez.Modules.CustomScriptableObjects.Core.Variables;

namespace Cordonez.BubbleInvasion.Models
{
	[System.Serializable]
	public class EnemySpawnData
	{
		public SO_EnemyData EnemyData;
		public SO_Vector2[] SpawnForces;
	}
}