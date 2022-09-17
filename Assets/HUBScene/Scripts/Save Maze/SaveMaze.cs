using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// class causes error on build caused by functions belonging to UnityEditor namespace, this was easiest fix
public class SaveMaze : MonoBehaviour
{
    private bool generated = false;
    // Start is called before the first frame update

    /*private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !generated)
        {
            GameObject maze = this.gameObject;//GameObject.Find("Maze");
            SaveMazeAsPrefab(maze);
            generated = true;
        }
    }

    
    public void SaveMazeAsPrefab(GameObject gameObjectToMakeAsPrefab) {
        // removing maze generator scripts before saving as prefab 
        Destroy(gameObjectToMakeAsPrefab.GetComponent<MazeSpawner>());
        Destroy(gameObjectToMakeAsPrefab.GetComponent<SaveMaze>());

        string localPath = "Assets/HUBScene/Prefabs/" + gameObjectToMakeAsPrefab.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObjectToMakeAsPrefab, localPath, InteractionMode.UserAction);
    }
    */
}
