namespace Cordonez.BubbleInvasion.DataModels
{
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

	[System.Serializable]
	public class SpawnPoint
	{
		public Transform Point;
		public SO_EnemyData Enemy;
		public SO_Vector2[] SpawnForces;
	}
}