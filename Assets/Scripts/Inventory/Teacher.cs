using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Teacher : ScriptableObject
{
    public int id;
    public string name;
    public Dialogs dialog;
    public Item cardPersonal;
}

