using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get; private set;
    }

    public AudioSource jump;
    public AudioSource explode;
    public AudioSource broke;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Play(string sound)
    {
        switch (sound)
        {
            case "jump":
                jump.PlayOneShot(jump.clip);
                break;
            case "explode":
                explode.PlayOneShot(explode.clip);
                break;
            case "broke":
                broke.PlayOneShot(broke.clip);
                break;
            default:
                break;
        }
    }
}