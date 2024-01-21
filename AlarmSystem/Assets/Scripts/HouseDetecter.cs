using UnityEngine;
using UnityEngine.Events;

public class HouseDetecter : MonoBehaviour
{
	[SerializeField] private UnityEvent _alarmOn;
	[SerializeField] private UnityEvent _alarmOff;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Thief>() != null)
		{
			_alarmOn?.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Thief>() != null)
		{
			_alarmOff?.Invoke();
		}
	}

}
