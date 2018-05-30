using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class PlayerDeathHandler : MonoBehaviour
	{
		public SOEvent_void PlayerDeath;

		private void OnEnable()
		{
			PlayerDeath.AddListener(OnPlayerDeath);
		}

		private void OnDisable()
		{
			PlayerDeath.RemoveListener(OnPlayerDeath);
		}

		private void OnPlayerDeath()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
