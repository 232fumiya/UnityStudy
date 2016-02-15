//C# Example

using UnityEngine;
using UnityEditor;
using System.Collections;
class checker : EditorWindow {
	[MenuItem ("Window/checker")]	
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(checker));
	}
	
	void OnGUI () {
		// The actual window code goes here
		int qualityLevel = QualitySettings.GetQualityLevel();
		int vSync = QualitySettings.vSyncCount;
		string isVSync="YES";
		if (vSync == 0) {
			isVSync="NO";
		}
		GUILayout.Label ("FPSchecker", EditorStyles.boldLabel);
		GUILayout.Label("vSync="+isVSync);
		GUILayout.Label ("targetFPS=" + Application.targetFrameRate);
		GUILayout.Label("QualityLevel="+qualityLevel.ToString ());
	}
}