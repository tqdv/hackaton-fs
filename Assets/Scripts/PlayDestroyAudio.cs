using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDestroyAudio : MonoBehaviour
{
	public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnDestroy ()
	{
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}
}
