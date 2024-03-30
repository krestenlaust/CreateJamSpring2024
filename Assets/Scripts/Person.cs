using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Person", menuName = "ScriptableObjects/Person", order = 1)]
public class Person : ScriptableObject
{
    public new string name;
    public Sprite avatar;
    public List<Convo> convos;
}
