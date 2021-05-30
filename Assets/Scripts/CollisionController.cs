/// Author: Yağız A. AYER
/// Github: github.com/yagizayer
/// Date: 30 May 2021
/// Used Style guide: Google C# StyleGuide (https://google.github.io/styleguide/csharp-style.html)


using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteor")){
            // makes Invisible both projectiles till they reach certain distance from camera and destroy
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
