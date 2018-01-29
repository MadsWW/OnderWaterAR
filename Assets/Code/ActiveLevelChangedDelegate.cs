using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLevelChangedDelegate : MonoBehaviour {

    public delegate void LevelChanged(GameObject activeLevel, bool isActive);
    public static event LevelChanged OnLevelChange;
}
