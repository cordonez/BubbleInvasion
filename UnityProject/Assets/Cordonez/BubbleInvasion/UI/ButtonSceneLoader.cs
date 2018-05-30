using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cordonez.BubbleInvasion.UI
{
	[RequireComponent(typeof(Button))]
	public class ButtonSceneLoader : MonoBehaviour
	{
		public SO_Object Scene;

		public void Init(SO_Object _scene)
		{
			gameObject.name = _scene.Value.name;
			gameObject.transform.GetChild(0).GetComponent<Text>().text = _scene.Value.name;
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