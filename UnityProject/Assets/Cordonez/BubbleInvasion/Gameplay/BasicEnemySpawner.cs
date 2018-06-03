using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class BasicEnemySpawner : MonoBehaviour
	{
		public SpawnPoint[] SpawnPoints;

		private void Start()
		{
			foreach (SpawnPoint spawnPoint in SpawnPoints)
			{
				foreach (SO_Vector2 spawnForce in spawnPoint.SpawnForces)
				{
					GameObject instaced = Instantiate(spawnPoint.Enemy.Value.Prefab, spawnPoint.Point.position, Quaternion.identity);
					instaced.GetComponent<IEnemy>().Init(spawnPoint.Enemy, spawnForce);
				}
			}
		}
	}
}
