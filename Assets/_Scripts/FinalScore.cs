using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalScore : MonoBehaviour
{
    public ScriptableScore s;
    public TextMeshProUGUI sT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sT.text = Mathf.Round(s.SScore).ToString();
    }
}
