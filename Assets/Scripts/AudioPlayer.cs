using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
	AudioSource m_MyAudioSource;

	void Start()
	{
		//Fetch the AudioSource from the GameObject
		m_MyAudioSource = GetComponent<AudioSource>();
	}
		
}