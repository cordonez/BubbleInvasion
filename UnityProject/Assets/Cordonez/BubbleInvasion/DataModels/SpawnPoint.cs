using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.DataModels
{
	[System.Serializable]
	public class SpawnPoint
	{
		public Transform Point;
		public SO_EnemyData Enemy;
		public SO_Vector2[] SpawnForces;
	}
}