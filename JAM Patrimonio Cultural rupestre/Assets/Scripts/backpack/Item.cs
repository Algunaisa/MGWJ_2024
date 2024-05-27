using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
[CreateAssetMenu(fileName ="New Item", menuName ="Rupestralia Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string description;
    public float value;

}
