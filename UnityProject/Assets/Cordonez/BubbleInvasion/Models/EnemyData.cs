using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Models
{
	[System.Serializable]
	public class EnemyData
	{
		public GameObject Prefab;
		public int Size;
		public SO_EnemySpawnData[] OnDestroyEnemies = new SO_EnemySpawnData[] { };
		public GameObject[] OnDestroyPrefabs = new GameObject[] { };
		public SO_Vector2 Velocity;
	}
}