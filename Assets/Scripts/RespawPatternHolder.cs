using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawPatternHolder : MonoBehaviour {

	// WHEN CREATING A PATTERN, MAKE SURE THE FIRST LINE IS THE ONE WITH THE BIGGEST NUMBER OF COLUMNS.
	// It is preferable to make all rows with the same size to avoid errors and strange behaviors. =D

	// spacing between bananas in the same row: 
	// Medium 	0,
	// Big 		0,0,

	// Single banana
	int[,] pattern1 = new int[,] { 
		{ 1 } };

	//Square pattern
	int[,] pattern2 = new int[,] { 
		{ 1, 0,0, 0, 1 },
		{ 1, 0,0, 0, 1 }};

	//To the right Line
	int[,] pattern3 = new int[,] { 
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
		{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		};

	//to the left line
	int[,] pattern4 = new int[,] { 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
	};

	//Curve
	int[,] pattern5 = new int[,] { 
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
		{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
	};

	// Big Square
	int[,] pattern6 = new int[,] {
		{ 1, 0,0, 1, 0,0, 1, 0,0, 1, 0,0, 1},
		{ 1, 0,0, 0, 0,0, 0, 0,0, 0, 0,0, 1},
		{ 1, 0,0, 0, 0,0, 1, 0,0, 0, 0,0, 1},
		{ 1, 0,0, 0, 0,0, 1, 0,0, 0, 0,0, 1},
		{ 1, 0,0, 0, 0,0, 0, 0,0, 0, 0,0, 1},
		{ 1, 0,0, 1, 0,0, 1, 0,0, 1, 0,0, 1}};



	// Create a list of parts.
	List<int[,]> patterns = new List<int[,]>();


		
	// Use this for initialization
	void Start () {

		// Add patterns to the list.
		patterns.Add(pattern1);
		patterns.Add(pattern2);
		patterns.Add(pattern3);
		patterns.Add(pattern4);
		patterns.Add(pattern5);
		patterns.Add(pattern6);
		
	}

	int currentPattern = 0;

	public int[,] getNextPattern()
	{
		Debug.Log (" Current pattern: " + currentPattern + " patterns.Count:" + patterns.Count);
		int[,] retPattern;

		retPattern = patterns[currentPattern];
		currentPattern++;

		if (currentPattern >= patterns.Count) {
			currentPattern = 0;
		}

		//TODO make the pattern me choosen ramdonly
		return retPattern;

	}
		

	private static RespawPatternHolder _instance;

	public static RespawPatternHolder Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject fbm = new GameObject("RespawPatternHolder");
				fbm.AddComponent<RespawPatternHolder>();
			}

			return _instance;
		}
	}


	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		_instance = this;
	}

}
