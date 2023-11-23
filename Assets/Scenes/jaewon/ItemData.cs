using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static ItemData instace;
    private void Awake()
    {
        instace = this;
    }
    public List<Item> itemDB = new List<Item>();
}
