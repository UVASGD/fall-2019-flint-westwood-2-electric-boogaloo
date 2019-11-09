using UnityEditor;

[InitializeOnLoad]
public class SaveOnRun {

    static SaveOnRun() {
        EditorApplication.playModeStateChanged += SaveScene;
    }

    static void SaveScene(PlayModeStateChange state) {
        UnityEngine.SceneManagement.Scene activeScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
        if (!EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isPlaying || !activeScene.isDirty) return;
        //Debug.Log("Auto-Saving scene before entering Play mode: " + activeScene.name);
        UnityEditor.SceneManagement.EditorSceneManager.SaveScene(activeScene);
        AssetDatabase.SaveAssets();

    }
}
