using Cordonez.Modules.CustomScriptableObjects.Core;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Cordonez.BubbleInvasion.UI
{
	[RequireComponent(typeof(Text))]
	public abstract class SOToText<TSo, TSoType> : MonoBehaviour where TSo : CustomScriptableObject<TSoType>
	{
		public TSo ScriptableVariable;
		public SOEvent_void ValueUpdated;

		private Text m_text;

		private void Awake()
		{
			m_text = GetComponent<Text>();
			OnValueUpdate();
		}

		private void OnEnable()
		{
			ValueUpdated.AddListener(OnValueUpdate);
		}

		private void OnDisable()
		{
			ValueUpdated.RemoveListener(OnValueUpdate);
		}

		private void OnValueUpdate()
		{
			m_text.text = ScriptableVariable.Value.ToString();
		}
	}
}