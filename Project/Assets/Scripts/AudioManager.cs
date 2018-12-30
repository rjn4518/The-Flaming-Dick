using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;    //Name of audio clip
    public AudioClip clip; //Audio clip file

    [Range(0f, 1f)]
    public float volume = 0.7f;  //Creates a slider to adjust audio volume
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;     //Creates a slider to adjust audio pitch

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;  //Allows for random variation in audio volume (set to 0 for no variation)
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;   //Allows for random variation in audio pitch (set to 0 for no variation)

    public bool loop = false;  //Determines whether or not audio clip loops

    private AudioSource source;  //Variable to assign audio clip and info about how it is played

    public void SetSource(AudioSource _source)  //Assigns audio and loop info to source variable
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Play()  //Plays audio at specified volume and pitch
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }

    public void Stop()  //Stops playing audio clip
    {
        source.Stop();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  //Creates instance of AudioManager script for other scripts to reference

    [SerializeField]
    Sound[] sounds;  //Array to store all audio clips in. Size of array can be specified in the inspector

    private void Awake()  //Function perfomed once when loading script
    {
        if (instance != null)  //If an instance for some reason already exists, destroy it
        {
            if (instance != this)         
                Destroy(this.gameObject);
        }
        else                  //Set the instance to this (the AudioManager script) and don't destroy it when loading another scene
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()  //Function performed once when loading script, but right after awake function
    {
        for (int i = 0; i < sounds.Length; i++)  //Creates new game object for each sound, makes them children of AudioManager game object, and calls SetSource function
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

        PlaySound("Music");
        StopSound("Music");

    }
        public void PlaySound(string _name)  //Searches for correct sound and then plays it
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                if(sounds[i].name == _name)
                {
                    sounds[i].Play();
                    break;
                }
                else if (i == sounds.Length - 1)
                    Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
            }
        }

       public void StopSound(string _name)  //Searches for correct sound and then stops playing it
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                if (sounds[i].name == _name)
                {
                    sounds[i].Stop();
                    break;
                }
                else if (i == sounds.Length - 1)
                    Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
            }
        }   
}
