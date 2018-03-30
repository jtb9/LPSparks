using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Controller : MonoBehaviour {

	// General configuration and state information
	int[] currentLP = new int[2];
	int[] targetLP = new int[2];

	// References
	public GameObject[] damagePrefabs;
	public TextMeshProUGUI player1Label;
	public TextMeshProUGUI player2Label;

	
	void Start () {
		reset();
	}
	
	
	// Track what our "target" lp values should be and be controlling
	// the animations for them
	void Update () {

		updateValueForAnimation(0);
		updateValueForAnimation(1);

		// Update the labels
		player1Label.text = currentLP[0].ToString();
		player2Label.text = currentLP[1].ToString();	
	}

	void updateValueForAnimation(int index) {
		currentLP[index] = (int)Mathf.MoveTowards(currentLP[index], targetLP[index], Configuration.LP_LABEL_ANIMATION_SPEED);
	}

	public void affectPlayer1(int ammount) {
		targetLP[0] += ammount;
	}

	public void affectPlayer2(int ammount) {
		targetLP[1] += ammount;
	}

	public void reset() {
		// Initialize our starting LP Counts
		int STARTING_LP = Configuration.DEFAULT_STARTING_LP;
		
		currentLP[0] = STARTING_LP;
		currentLP[1] = STARTING_LP;

		targetLP[0] = STARTING_LP;
		targetLP[1] = STARTING_LP;
	}
}
