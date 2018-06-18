using System.Collections;
using Cordonez.BubbleInvasion.DataModels;
using Cordonez.BubbleInvasion.Models;
using Cordonez.Modules.CustomScriptableObjects.Core.Events;
using Cordonez.Modules.CustomScriptableObjects.Core.Variables;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Gameplay
{
	public class FireBullet : MonoBehaviour
	{
		public SO_int BulletsLeft;
		public SO_WeaponData WeaponData;
		public SOEvent_void ShootRequest;
		public SOEvent_void Shoot;

		private float m_nextFireTime;

		private void OnEnable()
		{
			ShootRequest.AddListener(OnShootRequest);
			BulletsLeft.Value = WeaponData.Value.WeaponParams.Value.ClipSize;
		}

		private void OnDisable()
		{
			ShootRequest.RemoveListener(OnShootRequest);
		}

		private void OnShootRequest()
		{
			if (Time.time < m_nextFireTime)
			{
				return;
			}

			ShootBullet();
			if (BulletsLeft == 0)
			{
				StartCoroutine(Reload());
			}
		}

		private void ShootBullet()
		{
			Shoot.Invoke();
			IBullet bullet = Instantiate(WeaponData.Value.BulletData.Value.BulletPrefab, transform.position, Quaternion.identity).GetComponent<IBullet>();
			bullet.BulletData = WeaponData.Value.BulletData;
			bullet.Shoot();
			m_nextFireTime = Time.time + 1f / WeaponData.Value.WeaponParams.Value.FireRatePerSecond;
			BulletsLeft.Value = BulletsLeft - 1;
		}

		private IEnumerator Reload()
		{
			m_nextFireTime = Time.time + 1f / WeaponData.Value.WeaponParams.Value.ReloadTime;
			yield return new WaitForSeconds(WeaponData.Value.WeaponParams.Value.ReloadTime);
			BulletsLeft.Value = WeaponData.Value.WeaponParams.Value.ClipSize;
		}
	}
}