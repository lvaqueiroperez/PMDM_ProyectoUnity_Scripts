using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script usado para hacer que las monedas del Nivel roten
public class RotateCoin : MonoBehaviour {

	public GameObject coin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		coin.transform.Rotate (new Vector3 (0, 10,0));

	}

}
