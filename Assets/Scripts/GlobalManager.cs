using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    // public float Volume;
    // public float changeableVolume;
    // public Slider volumeSlider;
    public int maxLivScore;
    public Manager manager;
    private static GameObject globalManager;

    void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            manager = null;
        }
        
        if (globalManager)
        {
            Destroy(gameObject);
        }
        else
        {
            globalManager = gameObject;
        }
        LoadGame();
    }

    public void SaveGame()
    {
        var state = new GameState();
        state.Version = 1;
        state.Score = manager.errorCount;

        var filename = Path.Combine(Application.persistentDataPath, "game.sav");

        using (var stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
        {
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, state);
        }
        Debug.Log("Saved!");
    }

    public void LoadGame()
    {
        var filename = Path.Combine(Application.persistentDataPath, "game.sav");

        if (!File.Exists(filename))
        {
            return;
        }

        using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            var serializer = new BinaryFormatter();
            GameState state = (GameState) serializer.Deserialize(stream);

            switch (state.Version)
            {
                case 1:
                    
                    maxLivScore = state.Score;
                    break;
            }
        }
    }

    [System.Serializable]
    public struct GameState
    {
        public int Version;
        public int Score;
    }
}
