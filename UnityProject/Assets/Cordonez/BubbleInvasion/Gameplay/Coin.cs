using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Coin : MonoBehaviour
	{
		public SO_Layermask PlayerLayermask;
		public SO_int Coins;
		public SO_Vector2[] SpawnForce;

		private Rigidbody2D m_rigidbody2D;

		private void Awake()
		{
			m_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			m_rigidbody2D.AddForce(SpawnForce[Random.Range(0, SpawnForce.Length)].Value, ForceMode2D.Force);
		}

		private void OnCollisionEnter2D(Collision2D _other)
		{
			if (PlayerLayermask.ContainsLayer(_other.gameObject.layer))
			{
				Coins.Value = Coins.Value + 1;
				Destroy(gameObject);
			}
		}
	}
}