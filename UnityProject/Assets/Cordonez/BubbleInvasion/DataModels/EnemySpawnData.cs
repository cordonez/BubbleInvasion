using Cordonez.Modules.CustomScriptableObjects.Core.Variables;

namespace Cordonez.BubbleInvasion.DataModels
{
	[System.Serializable]
	public class EnemySpawnData
	{
		public SO_EnemyData EnemyData;
		public SO_Vector2[] SpawnForces;
	}
}