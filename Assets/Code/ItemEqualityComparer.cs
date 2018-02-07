using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class ItemEqualityComparer : EqualityComparer<Item>
    {
    public override bool Equals(Item x, Item y)
    {
        return Equals(x.ItemIndexNr, y.ItemIndexNr);
    }

    public override int GetHashCode(Item obj)
    {
        return obj.ItemIndexNr.GetHashCode();
    }
}

