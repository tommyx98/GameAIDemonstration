using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextChanger 
{
    private FileReader fileReader = new FileReader();
    private string txtFilePath = "./Assets/Shared/Resources/TextFiles/"; // previously used in editor mode, not possible on build
    public void SetControlsMenuText(Text text) {
        int chooser = SceneManager.GetActiveScene().buildIndex;

        switch(chooser)
        {
            case 0:
                text.text = fileReader.ReadFile(Application.streamingAssetsPath + "/0" + ".txt");
                break;

            case 1:
                text.text = fileReader.ReadFile(Application.streamingAssetsPath + "/1" + ".txt");
                break;

            case 2:
                text.text = fileReader.ReadFile(Application.streamingAssetsPath + "/2" + ".txt");
                break;

            case 3:
                text.text = fileReader.ReadFile(Application.streamingAssetsPath + "/3" + ".txt");
                break;

            case 4:
                text.text = fileReader.ReadFile(Application.streamingAssetsPath + "/4" + ".txt");
                break;

            case 5:
                text.text = fileReader.ReadFile(Application.streamingAssetsPath + "/5" + ".txt");
                break;

            default:
                text.text = string.Empty;
                break;
        }
    }
}
