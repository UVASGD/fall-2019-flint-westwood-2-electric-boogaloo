using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoDrop : MonoBehaviour
{
    public Weapon ammo; // The actual C# class of "weapon"
    public GameObject bullet; // The prefab associated with the ammo pickup. Located in Assets/Scripts/Scriptable Objects/Weapons

    // Start is called before the first frame update
    void Start()
    {
        // The ammo ought to be instantiated at the place where the enemy died.
        // Problem being, I don't fucking know how to "pass in" the location of the dead enemy :/
        // My god this is some awful spaghetti code :(((
        Instantiate(bullet, transform.position, Quaternion.identity); // I'm actually not sure if this works tbh, but I went off of the tutorial on Unity's website
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // Again, no clue WHAT the fuck I'm doing
    {
        // When the player walks over the ammo pickup, as it stands, their ammo pool (of 6 bullets) gets reset
        // I believe the original intent was to also have different ammo types as powerups, but that is on the backburner.

        // I don't know quite exactly how to call the player's ammo count, or if the player even has an ammo count, but
        // the gist is that it would go something like this:

        // If <ollider  
        // ammoCount = ammo.numBullets <-- numBullets being a field of Weapon, assigned to the prefab

    }
}
