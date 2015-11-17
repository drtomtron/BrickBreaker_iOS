using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	public Sprite[] hitSprites;
	public GameObject brick;
	public static int brickCount = 0;
	public AudioClip hitBrick;
	
	// Use this for initialization
	void Start () {
		isBreakable  = (this.tag == "Breakable");
		//keep track of breakable bricks
		if (isBreakable) {
			brickCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void loadSprite() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	void OnCollisionEnter2D (Collision2D collider) {
		AudioSource.PlayClipAtPoint (hitBrick, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		timesHit++; 
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
			brickCount--;
			Debug.Log(brickCount);
			levelManager.BrickDestroyed();
			Destroy (brick);
		} else {
			loadSprite();
		}
	}

}
