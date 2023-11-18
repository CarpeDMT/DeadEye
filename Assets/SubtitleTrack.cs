using System.Collections;
using System.Collections.Generic;
using UnityEngine;         
using UnityEngine.UI;      
using TinyGiantStudio.Text;


 public class SubtitleTrack : MonoBehaviour
    
{ 

public Modular3DText newText;

public string Subtext;
public Text Oldtext;

public void FixedUpdate()
{
    Subtext = Oldtext.text;

    newText.UpdateText(Subtext);


}


}
