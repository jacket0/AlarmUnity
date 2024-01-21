using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
	[SerializeField] private float _volumeIncreaseSpeed = 1f;

	private AudioSource _audioSource;
	private float _maxVolume = 1;
	private float _minVolume = 0;
	private Coroutine _coroutine;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void StartAlarm()
	{
		_audioSource.Play();
		_coroutine = StartCoroutine(ChangeVolume(_maxVolume));
	}

	public void StopAlarm()
	{
		StopCoroutine(_coroutine);
		_coroutine = StartCoroutine(ChangeVolume(_minVolume));

		if (_audioSource.volume == _minVolume)
			_audioSource.Stop();
	}

	private IEnumerator ChangeVolume(float limit)
	{
		while (_audioSource.volume != limit)
		{
			_audioSource.volume = Mathf.MoveTowards(_audioSource.volume, limit, _volumeIncreaseSpeed * Time.deltaTime);
			yield return null;
		}
	}
}
