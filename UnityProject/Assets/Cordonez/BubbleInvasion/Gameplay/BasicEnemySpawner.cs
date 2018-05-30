using Cordonez.BubbleInvasion.Models;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class BasicEnemySpawner : MonoBehaviour
	{
		[System.Serializable]
		public struct SpawnPoint
		{
			public Transform Point;
			public SO_EnemyData Enemy;
		}

		public SpawnPoint[] SpawnPoints;

		private void Start()
		{
			foreach (SpawnPoint spawnPoint in SpawnPoints)
			{
				GameObject instaced = Instantiate(spawnPoint.Enemy.Value.Prefab, spawnPoint.Point.position, Quaternion.identity);
				instaced.GetComponent<IEnemy>().Init(spawnPoint.Enemy);
			}
		}
	}
}
