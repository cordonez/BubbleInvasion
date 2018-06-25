namespace Cordonez.BubbleInvasion.UI
{
	using Modules.CustomScriptableObjects.Core.Collections;
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;

	public class MenuScenes : MonoBehaviour
	{
		public SOArray_Scene[] Worlds;

		public GameObject WorldContainer;
		public GameObject ButtonLevel;

		private void Start()
		{
			foreach (SOArray_Scene world in Worlds)
			{
				GameObject worldContainer = Instantiate(WorldContainer, transform);
				foreach (SO_Scene scene in world.Value)
				{
					GameObject button = Instantiate(ButtonLevel, worldContainer.transform);
					button.AddComponent<ButtonSceneLoader>().Init(scene);
				}
			}
		}
	}
}