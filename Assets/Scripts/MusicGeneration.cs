using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGeneration : MonoBehaviour {
    
    private AudioSource randomNote;
    private AudioSource[] notes;

    public float notesDelay;

    void Start()
    {

        notes = GetComponents<AudioSource>();
        StartCoroutine(RandomNote());

    }

    IEnumerator RandomNote ()
    {
    
        while (true)
        {

            // Récupère une note parmis toutes et la joue
            randomNote = notes[Random.Range(0, notes.Length)];
            randomNote.volume = Random.Range(0.3f, 0.6f);
            randomNote.Play();
            
            // Randomize le delay entre deux notes
            float randomNotesDelay = notesDelay + Random.Range(0, 5);

            yield return new WaitForSeconds(randomNotesDelay);

        }

    }
    

}
