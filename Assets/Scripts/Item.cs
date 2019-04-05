using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject {

    public float id;
    new public string NameItem = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

}
