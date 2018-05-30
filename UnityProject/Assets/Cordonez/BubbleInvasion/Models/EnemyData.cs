using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Models
{
	[System.Serializable]
	public class EnemyData
	{
		public GameObject Prefab;
		public int Size;
		public SO_EnemyData[] OnDestroyEnemies = new SO_EnemyData[] { };
		public GameObject[] OnDestroyPrefabs = new GameObject[] { };
		public Vector2 Velocity;
		public SO_Vector2[] SpawnForce = new SO_Vector2[] { };
	}
}