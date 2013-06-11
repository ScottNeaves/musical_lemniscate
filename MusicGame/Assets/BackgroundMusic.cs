using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class BackgroundMusic : MonoBehaviour {
	
	public AudioClip topSlow;
	public AudioClip topFast;
	public AudioClip bottomSlow;
	public AudioClip bottomFast;
	
	private int currTime;
	
	// Use this for initialization
	void Start () {
		audio.loop = true;
		setMusic();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Sets the music that is playing based on clef and follower
	// This is called from player   (when warped)
	//                from follower (when following toggled)
	public void setMusic() {
		Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
		FollowerMove follower = GameObject.FindObjectOfType(typeof(FollowerMove)) as FollowerMove;
		bool sameLevel = (player.isOnTop == follower.isOnTop);
		
		currTime = audio.timeSamples;
		
		if (player.isOnTop) {
			if (follower.isFollowing && sameLevel)
				audio.clip = topFast;
			else
				audio.clip = topSlow;
		}
		else {
			if (follower.isFollowing && sameLevel)
				audio.clip = bottomFast;
			else
				audio.clip = bottomSlow;
		}
		
		audio.timeSamples = currTime;
		audio.Play();
	}
}