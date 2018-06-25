namespace Cordonez.BubbleInvasion.DataModels
{
	using UnityEngine;

	[System.Serializable]
	public class EnemyData
	{
		public GameObject Prefab;
		public int Hp;
		public float Size;
		public float HorizontalVelocity;
		public float JumpForce;
		public float GravityScale;
		public float SpawnFreq;
		public SO_EnemySpawnData[] Spawn;
		public SO_EnemySpawnData[] OnDestroyEnemies = { };
		public GameObject[] OnDestroyPrefabs = { };
	}
}