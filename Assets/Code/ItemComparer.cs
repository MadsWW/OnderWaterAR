using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComparer : Comparer<Item>
{

    public override int Compare(Item x, Item y)
    {
        if (x == null && y == null)
        {
            return 0;
        }
        if (x == null)
        {
            return -1;
        }
        if (y == null)
        {
            return 1;
        }

        return x.ItemIndexNr.CompareTo(y.ItemIndexNr);
    }

}
