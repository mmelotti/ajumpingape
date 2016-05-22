using UnityEngine;
using System.Collections;

public class InstanceBananasAndBrains : MonoBehaviour {

	public GameObject[] waypoints = null;
	public int numberOfWaypoints = 21;
	public float waypointsInterval = 0.25F;
	public float initialXPosition = -2.5F;
	public GameObject waypointToInstantiate = null;

	public GameObject bananaToInstantiate = null;
	public GameObject brainToInstantiate = null;

	private GameObject[] bananaPool = null;
	private GameObject[] brainPool = null;

	public int bananaPoolSize = 50;
	public int brainPoolSize = 5;

	private RespawPatternHolder respaw;
	// Use this for initialization
	void Start () {

		//TODO: also get the parameters from GameBalanceManager

		waypoints = new GameObject[numberOfWaypoints];
		float currentWaypointPosition = initialXPosition;
		for (int i = 0; i < numberOfWaypoints; i++) {
			waypoints [i] = Instantiate (waypointToInstantiate) as GameObject;
			waypoints [i].transform.parent = gameObject.transform;
			waypoints[i].transform.Translate( currentWaypointPosition ,waypoints [i].transform.parent.position.y,0);
			currentWaypointPosition += waypointsInterval;
		}

		bananaPool = new GameObject[bananaPoolSize];
		for (int i = 0; i < bananaPoolSize; i++) {
			bananaPool [i] = Instantiate (bananaToInstantiate) as GameObject;
			bananaPool [i].transform.parent = gameObject.transform;
			bananaPool [i].SetActive (false);
		}


		brainPool = new GameObject[brainPoolSize];
		for (int i = 0; i < brainPoolSize; i++) {
			brainPool [i] = Instantiate (brainToInstantiate) as GameObject;
			brainPool [i].transform.parent = gameObject.transform;
			brainPool [i].SetActive (false);
		}

		respaw = RespawPatternHolder.Instance;
	}
	
	public void ActivateObjectBanana()
	{
		for (int i = 0; i < bananaPoolSize; i++) {
			if (bananaPool [i].activeInHierarchy == false) {
				bananaPool [i].SetActive (true);
				return;
			}
		}
	}

	public void ActivateObjectBananaAtWaypoint(int waypointNumber)
	{
		for (int i = 0; i < bananaPoolSize; i++) {
			if (bananaPool [i].activeInHierarchy == false) {
				bananaPool [i].SetActive (true);
				bananaPool [i].transform.position = waypoints [waypointNumber].transform.position;
				return;
			}
		}
	}

	public void ActivateObjectBrain()
	{
		for (int i = 0; i < brainPoolSize; i++) {
			if (brainPool [i].activeInHierarchy == false) {
				brainPool [i].SetActive (true);
				return;
			}
		}
	}

	public void ActivateObjectBrainAtWaypoint(int waypointNumber)
	{
		for (int i = 0; i < brainPoolSize; i++) {
			if (brainPool [i].activeInHierarchy == false) {
				brainPool [i].SetActive (true);
				brainPool [i].transform.position = waypoints [waypointNumber].transform.position;
				return;
			}
		}
	}


	public float respawTime;
	public float brainRespawTime;
	private float timer;
	private float timer2;

	//private int currentWaypoint = 0;
	private int[,] currentPattern = null;
	private int patternLineExecuted = 0;
	private int offset = 0;

	//First test to instantiate by time
	void Update()
	{
		if (Time.time > timer + respawTime) {
			timer = Time.time;
			//ActivateObjectBanana ();

			if (currentPattern == null) currentPattern = respaw.getNextPattern ();

			if (patternLineExecuted >= currentPattern.GetLength(0)) {
				currentPattern = respaw.getNextPattern ();
				patternLineExecuted = 0;
				// When we create a new Pattern, it can be spawned in diferent positions considering a random offset
				int maxOffset = numberOfWaypoints - currentPattern.GetLength (1);
				offset = Random.Range (0, maxOffset);

			} else {
				for (int i = 0; i < currentPattern.GetLength (1); i++) {
					int value = currentPattern [patternLineExecuted, i];
					Debug.Log ("Pattern cur Row"+patternLineExecuted+" Col:" + i+ " value:" + currentPattern [patternLineExecuted, i]);
					if (value==1) {
						ActivateObjectBananaAtWaypoint (i+offset);
					}
				}
				patternLineExecuted++;
			}


			//ActivateObjectBananaAtWaypoint(currentWaypoint);
			//currentWaypoint++;
			//if (currentWaypoint >= numberOfWaypoints)
			//	currentWaypoint = 0;
		}

		if (Time.time > timer2 + brainRespawTime) {
			timer2 = Time.time;
							
			int offset = Random.Range (0, numberOfWaypoints);

			ActivateObjectBrainAtWaypoint (offset);
		}


	}
}
