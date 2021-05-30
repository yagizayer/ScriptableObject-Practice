using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMeteors : MonoBehaviour
{
    public Meteor meteor;
    public bool meteorShower = true;
    public float meteorSpawningRange = 8;
    public float meteorRespawningTime = 1;

    void Start()
    {
        StartCoroutine(meteorSpawnerControl());
    }

    IEnumerator meteorSpawnerControl()
    {
        while (meteorShower)
        {
            yield return new WaitForSeconds(meteorRespawningTime);
            GameObject tempMeteor = new GameObject("MeteorObject");

            tempMeteor.transform.parent = transform;
            tempMeteor.transform.position = new Vector3(Random.Range(-meteorSpawningRange, meteorSpawningRange), 6.5f, 0);
            tempMeteor.transform.localScale = Vector3.one * meteor.radius;
            tempMeteor.tag = "Meteor";

            SpriteRenderer spriteRenderer = tempMeteor.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = meteor.sprite;

            Rigidbody rigidbody = tempMeteor.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;

            SphereCollider sphereCollider = tempMeteor.AddComponent<SphereCollider>();
            sphereCollider.radius = meteor.radius;
            StartCoroutine(projectileProgress(tempMeteor, tempMeteor.transform.position, tempMeteor.transform.position + Vector3.down * 20, meteor.speed));
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
