using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was used from https://www.youtube.com/watch?v=1Y6suVBaBK8

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance; // Creates a static varible for a AudioManagerScript instance

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() // Runs before void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Don't destroy this gameObject when loading different scenes

        if (instance == null) // If the MusicControlScript instance variable is null
        {
            instance = this; // Set this object as the instance
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }
    }
}