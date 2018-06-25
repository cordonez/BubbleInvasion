namespace Cordonez.BubbleInvasion.Gameplay
{
	using Modules.CustomScriptableObjects.Core.Events;
	using UnityEngine;
	using UnityEngine.SceneManagement;

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