using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public ScriptableScore s;
    public void LoadThisLevel(string l)
    {
        SceneManager.LoadScene(l, LoadSceneMode.Single);
    }
    public void resetScore()
    {
        s.SScore = 0;
    }
}
