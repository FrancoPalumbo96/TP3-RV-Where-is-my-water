using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
	public GameObject tube1;
	public GameObject tube2;
	public GameObject tube3;
	public MeshRenderer pinkPanter;
	public GameObject panter;
	public GameObject bathtub;

	public GameObject tube1Reference;
	public GameObject tube2Reference;
	public GameObject tube3Reference;
	public float xLimit;
	public float yLimit;
	private bool finish;
	private float time;

	// Use this for initialization
	private void Start()
	{
		finish = true;
		time = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		time = time + Time.deltaTime;
		if (hasWon() && finish)
		{
			bathtub.GetComponent<MeshRenderer>().enabled = false;
			//pinkPanter.enabled = true;
			panter.GetComponent<MeshRenderer>().enabled = true;
			panter.GetComponent<VideoPlayer>().Play();
			finish = false;
			time = 0;
		}

		if (!finish && time>= 5)
		{
			if (SceneManager.GetActiveScene().buildIndex==0)
			{
				SceneManager.LoadScene(1);
			}
		}
	}

	private bool hasWon()
	{
		// 
		if (tube1.GetComponentInChildren<MeshRenderer>().enabled && tube2.GetComponentInChildren<MeshRenderer>().enabled && tube3.GetComponentInChildren<MeshRenderer>().enabled)
		{
			//
			return checkTargetRange(tube1,tube1Reference) && checkTargetRange(tube2,tube2Reference) && checkTargetRange(tube3, tube3Reference);
		}
		return false;
	}

	private bool checkTargetRange(GameObject tube, GameObject tubeReference)
	{
		if (tube.transform.position.x - xLimit<= tubeReference.transform.position.x &&
		    tube.transform.position.x + xLimit>= tubeReference.transform.position.x &&
		    tube.transform.position.y - yLimit<= tubeReference.transform.position.y &&
		    tube.transform.position.y + yLimit>= tubeReference.transform.position.y )
		{
			return true;
		}
		return false;
	}
}
