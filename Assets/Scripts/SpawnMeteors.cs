/// Author: Yağız A. AYER
/// Github: github.com/yagizayer
/// Date: 30 May 2021
/// Used Style guide: Google C# StyleGuide (https://google.github.io/styleguide/csharp-style.html)


using System.Collections;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    [Tooltip("ScriptableObject of Spawning meteor")]
    [SerializeField] private SO_Meteor _meteor;
    [Tooltip("Is meteors currently spawning?")]
    [SerializeField] private bool _meteorShower = true;
    [Tooltip("Meteor spawners width")]
    [SerializeField] [Range(.01f, 20f)] private float _meteorSpawningRange = 8;
    [Tooltip("Meteor spawning period (in Seconds)")]
    [SerializeField] [Range(.01f, 20f)] private float _meteorRespawningTime = 1;

    void Start()
    {
        StartCoroutine(meteorSpawnerControl());
    }

    IEnumerator meteorSpawnerControl()
    {
        while (_meteorShower)
        {
            yield return new WaitForSeconds(_meteorRespawningTime);
            GameObject tempMeteor = new GameObject("MeteorObject");

            tempMeteor.transform.parent = transform;
            tempMeteor.transform.position = new Vector3(Random.Range(-_meteorSpawningRange, _meteorSpawningRange), 6.5f, 0);
            tempMeteor.transform.localScale = Vector3.one * _meteor.Radius;
            tempMeteor.tag = "Meteor";

            SpriteRenderer spriteRenderer = tempMeteor.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _meteor.Sprite;

            Rigidbody rigidbody = tempMeteor.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;

            SphereCollider sphereCollider = tempMeteor.AddComponent<SphereCollider>();
            sphereCollider.radius = _meteor.Radius;
            StartCoroutine(projectileProgress(tempMeteor, tempMeteor.transform.position, tempMeteor.transform.position + Vector3.down * 20, _meteor.Speed));
        }
    }

    IEnumerator projectileProgress(GameObject holder, Vector3 from, Vector3 to, float speed)
    {
        float lerp = 0;
        while (lerp < 1)
        {

            holder.transform.position = Vector3.Lerp(from, to, lerp);
            lerp += Time.deltaTime * speed;
            yield return null;
        }
        if (lerp > 1)
        {
            GameObject.Destroy(holder);
        }
    }
}
