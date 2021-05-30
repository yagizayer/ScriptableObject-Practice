using UnityEngine;

[CreateAssetMenu(fileName = "New Meteor", menuName = "Meteor", order = 2)]
public class Meteor : ScriptableObject
{
    public Sprite sprite;
    [Range(.1f, 10)]
    public float radius;
    [Range(.01f, 1)]
    public float speed;
}
