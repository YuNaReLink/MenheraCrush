using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(fileName = "CharacterInfo", menuName = "ScriptableObjects/CharacterInfo", order = 1)]
public class CharacterInfo : ScriptableObject
{
    public new string name;
    public string comment;
    public Sprite skillDetail;
    public Sprite fullBody;
    public Sprite normalFace;
    public Sprite yamiFace;
    public Sprite backImage;


}
