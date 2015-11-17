using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	
	static MusicController instance = null;
	// Use this for initialization
	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate Music Player Destroyed");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
