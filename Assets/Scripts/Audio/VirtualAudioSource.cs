using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualAudioSource : MonoBehaviour
{
	public GameObject target;
	public Vector3 targetPosition;
	public VirtualAudioListener listener;

	void LateUpdate()
	{
		if (target == null && targetPosition == null  || listener == null)
		{
			gameObject.SetActive(false);
			return;
		}
		if (target != null)
		{
			targetPosition = target.transform.position;
		}

		transform.position = Quaternion.Inverse(listener.transform.rotation) * (targetPosition - listener.transform.position) + VirtualAudioListener.masterListener.transform.position;
	}

	public VirtualAudioListener GetClosestListener()
	{
		int indexToReturn = 0;
		float shortestDistance = Mathf.Infinity;
		for (int i = 0; i < VirtualAudioListener.Listeners.Count; i++)
		{
			if ((targetPosition - VirtualAudioListener.Listeners[i].transform.position).sqrMagnitude < shortestDistance)
			{
				indexToReturn = i;
				shortestDistance = (targetPosition - VirtualAudioListener.Listeners[i].transform.position).sqrMagnitude;
			}
		}

		return VirtualAudioListener.Listeners[indexToReturn];
	}

	public void CalculateClosestListener(GameObject newTarget = null)
	{
		if (newTarget) target = newTarget;
		listener = GetClosestListener();
	}

	public void CalculateClosestListener(Vector3 newTargetPosition)
	{
		targetPosition = newTargetPosition;
		listener = GetClosestListener();
	}
}
