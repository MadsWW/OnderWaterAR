using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Item : MonoBehaviour, IComparable<Item>, IEquatable<Item>
{
    public int ItemIndexNr; // Will be set in Inspector
    public string ItemDescrip; // Will be set in Inspector

    // if we ever wanted to load data from outside.
    public void SetFields(string descrip, int indexNr)
    {
        ItemDescrip = descrip;
        ItemIndexNr = indexNr;
    }

    #region EQUALS_COMP_METHODS

    public int CompareTo(Item other)
    {
        if (this.ItemIndexNr < other.ItemIndexNr)
        {
            return -1;
        }
        else if (this.ItemIndexNr > other.ItemIndexNr)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public bool Equals(Item other)
    {
        if (other == null)
        {
            return false;
        }
        else
        {
            return this.ItemIndexNr == other.ItemIndexNr;
        }
    }

    public static bool operator == (Item x, Item y)
    {
        return Equals(x,y);
    }

    public static bool operator !=(Item x, Item y)
    {
        return !Equals(x,y);
    }

    public override bool Equals(object other)
    {
        if(other is Item)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return ItemIndexNr.GetHashCode();
    }

    #endregion // EQUALS_COMP_METHODS
}
