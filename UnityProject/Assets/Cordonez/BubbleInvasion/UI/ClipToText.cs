namespace Cordonez.BubbleInvasion.UI
{
	using DataModels;
	using Modules.CustomScriptableObjects.Core.Events;
	using Modules.CustomScriptableObjects.Core.Variables;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Text))]
	public class ClipToText : MonoBehaviour
	{
		public SO_WeaponData CurrentWeapon;
		public SOEvent_void WeaponUpdated;
		public SO_int BulletsLeft;

		private Text m_text;
		private string m_maxClipSize;

		private void Awake()
		{
			m_text = GetComponent<Text>();
			OnWeaponUpdated();
		}

		private void OnEnable()
		{
			BulletsLeft.AddListenerOnUpdate(OnBulletsLeftUpdated);
			WeaponUpdated.AddListener(OnWeaponUpdated);
		}

		private void OnBulletsLeftUpdated(int _arg1, int _arg2)
		{
			UpdateText(_arg2);
		}

		private void UpdateText(int _arg2)
		{
			m_text.text = _arg2 + m_maxClipSize;
		}

		private void OnDisable()
		{
			BulletsLeft.RemoveListenerOnUpdate(OnBulletsLeftUpdated);
			WeaponUpdated.RemoveListener(OnWeaponUpdated);
		}

		private void OnWeaponUpdated()
		{
			m_maxClipSize = "/" + CurrentWeapon.Value.WeaponParams.Value.ClipSize;
			UpdateText(BulletsLeft);
		}
	}
}