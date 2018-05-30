using System;
using UnityEngine;

namespace Cordonez.BubbleInvasion.Models
{
	[Serializable]
	public class WeaponParams
	{
		[SerializeField]
		private float m_fireRatePerSecond;
		[SerializeField]
		private int m_reloadTime;
		[SerializeField]
		private int m_clipSize;

		public float FireRatePerSecond
		{
			get { return m_fireRatePerSecond; }
			set { m_fireRatePerSecond = value; }
		}

		public int ReloadTime
		{
			get { return m_reloadTime; }
			set { m_reloadTime = value; }
		}

		public int ClipSize
		{
			get { return m_clipSize; }
			set { m_clipSize = value; }
		}
	}
}