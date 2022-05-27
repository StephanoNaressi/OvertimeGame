using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Boss",menuName ="Boss")]
public class DialogueChoiceObject : ScriptableObject
{
    public string CorrectChoice;
    public string WrongChoice1;
    public string WrongChoice2;
    public string WrongChoice3;
    public string Introduction;
    public string Conclusion;
    public string Question;
}
