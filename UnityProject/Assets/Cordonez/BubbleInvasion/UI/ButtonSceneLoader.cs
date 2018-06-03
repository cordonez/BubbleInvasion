using System.Linq;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cordonez.BubbleInvasion.UI
{
	[RequireComponent(typeof(Button))]
	public class ButtonSceneLoader : MonoBehaviour
	{
		public SO_Scene Scene;

		public void Init(SO_Scene _scene)
		{
			gameObject.name = _scene.Value;
			gameObject.transform.GetChild(0).GetComponent<Text>().text = _scene.Value.Split('/').Last().Split('.').First();
		}

		private void LoadScene()
		{
			SceneManager.LoadScene(gameObject.name);
		}

		private void Start()
		{
			GetComponent<Button>().onClick.AddListener(LoadScene);

			if (Scene != null)
			{
				Init(Scene);
			}
		}
	}
}