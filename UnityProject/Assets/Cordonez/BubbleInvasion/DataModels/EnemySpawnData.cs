namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core.Variables;

	[System.Serializable]
	public class EnemySpawnData
	{
		public SO_EnemyData EnemyData;
		public SO_Vector2[] SpawnForces;
	}
}