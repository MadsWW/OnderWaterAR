using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEqualityComparer : EqualityComparer<Item>
{

    public override bool Equals(Item x, Item y)
    {
        return Equals(x, y);
    }

    public override int GetHashCode(Item obj)
    {
        return obj.GetHashCode();
    }
}
