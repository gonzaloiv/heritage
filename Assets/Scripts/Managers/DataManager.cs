using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]
public class Leaderboard {

  public bool IsTutorialPlayer { get { return isTutorialPlayer; } set { isTutorialPlayer = value; } }
  private bool isTutorialPlayer = false;

  public int HighestScore { get { return highestScore; } set { highestScore = value; } }
  private int highestScore = 0;

}


public class DataManager : MonoBehaviour {

  #region Fields

  public static Leaderboard Leaderboard { get { return leaderboard; } }
  private static Leaderboard leaderboard;

  private static string dataPath;

  #endregion

  #region Mono Behaviour

  void Awake() {
    dataPath = Application.persistentDataPath;
    Debug.Log("Data: " + Application.persistentDataPath);
    leaderboard = new Leaderboard();
    LoadData();
  }

  void Start() {
    if(!GetIsTutorialPlayed())
      SetIsTutorialPlayed();
  }

  void OnDestroy() {
    SaveData();
  }

  #endregion

  #region Public Behaviour

  public static void SetIsTutorialPlayed() {
    leaderboard.IsTutorialPlayer = true;
  }

  public static bool GetIsTutorialPlayed() {
    return leaderboard.IsTutorialPlayer;
  }

  public static void SetHighestScore(int newScore) {
    leaderboard.HighestScore = newScore;
  }

  public static int GetHighestScore() {
    return leaderboard.HighestScore;
  }

  #endregion

  #region Private Behaviour


  private static void SaveData() {
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream saveFile = File.Create(dataPath + "/data.binary");
    formatter.Serialize(saveFile, leaderboard);
    saveFile.Close();
  }

  private static void LoadData() {
    try {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream saveFile = File.Open(dataPath + "/data.binary", FileMode.Open);
      leaderboard = (Leaderboard) formatter.Deserialize(saveFile);
      saveFile.Close();
    } catch (FileNotFoundException exception) {
      Debug.Log("First play: Data not recorded, yet");
    }
  }

  #endregion

}