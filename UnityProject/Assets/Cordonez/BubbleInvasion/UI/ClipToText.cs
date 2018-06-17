using Cordonez.BubbleInvasion.DataModels;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace Cordonez.BubbleInvasion.UI
{
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

		private void OnDisable()
		{
			BulletsLeft.RemoveListenerOnUpdate(OnBulletsLeftUpdated);
			WeaponUpdated.RemoveListener(OnWeaponUpdated);
		}

		private void OnBulletsLeftUpdated()
		{
			m_text.text = BulletsLeft.Value + m_maxClipSize;
		}

		private void OnWeaponUpdated()
		{
			m_maxClipSize = "/" + CurrentWeapon.Value.WeaponParams.Value.ClipSize;
			OnBulletsLeftUpdated();
		}
	}
}