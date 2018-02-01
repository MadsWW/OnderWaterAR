using System;
using UnityEngine;

public class LevelChangeEventArgs : EventArgs
{
    public GameObject ActiveLevel { get; set; }
    public bool IsActive { get; set; }
}
