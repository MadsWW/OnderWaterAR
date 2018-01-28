using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLevelChangedDelegate : MonoBehaviour {

    public delegate void LevelChanged(object sender, EventArgs args);
    public event LevelChanged OnLevelChange;
}
