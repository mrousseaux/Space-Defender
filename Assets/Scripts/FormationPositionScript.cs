﻿using UnityEngine;
using System.Collections;

public class FormationPositionScript : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 1f);
	}
}
