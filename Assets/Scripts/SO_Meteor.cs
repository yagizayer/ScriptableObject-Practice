/// Author: Yağız A. AYER
/// Github: github.com/yagizayer
/// Date: 30 May 2021
/// Used Style guide: Google C# StyleGuide (https://google.github.io/styleguide/csharp-style.html)

using UnityEngine;

[CreateAssetMenu(fileName = "New Meteor", menuName = "Meteor", order = 2)]
public class SO_Meteor : ScriptableObject
{
    [Tooltip("Sprite of Meteor")]
    public Sprite Sprite;
    [Tooltip("Collision Range of Meteor")]
    [Range(.1f, 10)] public float Radius = 1f;
    [Tooltip("Descending Speed of Meteor")]
    [Range(.01f, 1)] public float Speed = 1f;
}
