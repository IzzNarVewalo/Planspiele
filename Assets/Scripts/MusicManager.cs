using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static string configPath = "Assets/Resources/Music/Clips.music";
    private static string musicPath = "Music/";
    private AudioClip guitarStart;
    private AudioClip pianoStart;
    private AudioClip bassStart;
    private static LinkedList<string> pianoFiles = new LinkedList<string>();
    private static LinkedList<string> guitarFiles = new LinkedList<string>();
    private static LinkedList<string> bassFiles = new LinkedList<string>();
    private LinkedList<AudioClip> guitarClips = new LinkedList<AudioClip>();
    private LinkedList<AudioClip> pianoClips = new LinkedList<AudioClip>();
    private LinkedList<AudioClip> bassClips = new LinkedList<AudioClip>();

    [SerializeField]
    AudioSource guitarSource;
    [SerializeField]
    AudioSource pianoSource;
    [SerializeField]
    AudioSource bassSource;
    public static MusicManager instance = null;
    //public float lowPitchRange = .95f;
    //public float highPitchRange = 1.05f;


	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        LoadClips();
        FirstClip();
	}

    private void Update()
    {
        if (!guitarSource.isPlaying)
        {
            RandomizeClips();
        }
    }

    private void FirstClip()
    {
        guitarSource.clip = guitarStart;
        pianoSource.clip = pianoStart;
        bassSource.clip = bassStart;
        guitarSource.Play();
        pianoSource.Play();
        bassSource.Play();
    }

    //public AudioClip PickRandomClip(params AudioClip[] clips)
    //{
    //    int randomIndex = Random.Range(0, clips.Length);

    //    return clips[randomIndex];
    //}

    public void RandomizeClips()
    {
        //guitar
        LinkedList<AudioClip>.Enumerator en = guitarClips.GetEnumerator();
        int randomIndex = Random.Range(0, guitarClips.Count);
        for (int i = 0; i <= randomIndex; i++)
        {
            en.MoveNext();
        }
        guitarSource.clip = en.Current;
        en.Dispose();

        en = pianoClips.GetEnumerator();
        randomIndex = Random.Range(0, pianoClips.Count);
        for (int i = 0; i <= randomIndex; i++)
        {
            en.MoveNext();
        }
        pianoSource.clip = en.Current;
        en.Dispose();

        en = bassClips.GetEnumerator();
        randomIndex = Random.Range(0, bassClips.Count);
        for (int i = 0; i <= randomIndex; i++)
        {
            en.MoveNext();
        }
        bassSource.clip = en.Current;
        en.Dispose();

        guitarSource.Play();
        pianoSource.Play();
        bassSource.Play();
    }

    private void LoadClips()
    {
        AudioClip clip;
        string path = "";

        Parse();
        while (guitarFiles.Count != 0)
        {
            path = musicPath + guitarFiles.Last.Value;
            clip = Resources.Load(path) as AudioClip;
            print(clip + " // " + path);

            guitarClips.AddLast(clip);
            guitarFiles.RemoveLast();
        }
        while (pianoFiles.Count != 0)
        {
            path = musicPath + pianoFiles.Last.Value;
            clip = Resources.Load<AudioClip>(path);

            pianoClips.AddLast(clip);
            pianoFiles.RemoveLast();
        }
        while (bassFiles.Count != 0)
        {
            path = musicPath + bassFiles.Last.Value;
            clip = Resources.Load<AudioClip>(path);

            bassClips.AddLast(clip);
            bassFiles.RemoveLast();
        }

        guitarStart = Resources.Load<AudioClip>("Music/guitarStart.wav");
        pianoStart = Resources.Load<AudioClip>("Music/pianoStart.wav");
        bassStart = Resources.Load<AudioClip>("Music/bassStart.wav");
    }

    private void Parse()
    {
        System.IO.StreamReader reader = System.IO.File.OpenText(configPath);
        string line = "";
        string path = "";

        while ((line = reader.ReadLine()) != null)
        {
            if (line.Contains("#Bass"))
            {
                path = line.Substring(6);
                bassFiles.AddLast(path);
            }
            else if (line.Contains("#Piano"))
            {
                path = line.Substring(7);
                pianoFiles.AddLast(path);
            }
            else if (line.Contains("#Guitar"))
            {
                path = line.Substring(8);
                guitarFiles.AddLast(path);
            }
        }
    }
}
