using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// makeGameObj
/// 大量配置したいオブジェクトを自動生成する。
/// </summary>
class makeGameObj : EditorWindow {
	private  GameObject parent;
	private string parentName="parent";
	private  GameObject[] child=new GameObject[10];
	private string[] childName=new string[10];
	private int child_type=1;
	private Vector3 startPos=Vector3.zero;
	private Vector3 interval=new Vector3(1,1,1);
	private int makeCount=1;
	[MenuItem ("Window/makeGameObj")]

	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(makeGameObj));
	}
	void OnGUI() {
		try {
			GUILayout.Label("ParentGameObject: ", EditorStyles.boldLabel);
			parent = EditorGUILayout.ObjectField("Parent", parent, typeof(GameObject), true) as GameObject;
			parentName=EditorGUILayout.TextField("name", parentName);
			GUILayout.Label("type : ", EditorStyles.boldLabel);
			child_type = EditorGUILayout.IntSlider(child_type,1,10);
			if(child_type<1)
				child_type=1;
			else if(10<child_type)
				child_type=10;
			for(int i=0; i<child_type;i++)
			{
				GUILayout.Label("ChildGameObject["+i+"]:", EditorStyles.boldLabel);
				child[i]= EditorGUILayout.ObjectField("child", child[i], typeof(GameObject), true) as GameObject;
				childName[i]=EditorGUILayout.TextField("name", childName[i]);

			}
			GUILayout.Label("CreateFirstPosition: ", EditorStyles.boldLabel);
			startPos =EditorGUILayout.Vector3Field("Pos", startPos);
			GUILayout.Label("intervalPosition: ", EditorStyles.boldLabel);
			interval =EditorGUILayout.Vector3Field("interval", interval);

			
			GUILayout.Label("GenerationNumber : ", EditorStyles.boldLabel);
			makeCount = int.Parse(EditorGUILayout.TextField("num", makeCount.ToString()));

			if (GUILayout.Button("Create")) objCreater();
		} catch (System.FormatException) {}
	}
	private void objCreater()
	{
		Vector3 CreatePos = startPos;
		if (parent == null) 
		{
			parent = new GameObject();
		}
		parent.name=parentName;
		int childNum = 0;
		for (int j=0; j<makeCount; j++) 
		{
			int count=0;
			while(child[childNum]==null&&count<=10)
			{
				if(childNum+1<child_type)
					childNum++;
				else
					childNum=0;
				count++;
			}
			if(child[childNum]==null)
				return;
			GameObject childObj=Instantiate(child[childNum],CreatePos,Quaternion.identity)as GameObject;
			childObj.name=childName[childNum];
			if(childName[childNum]=="")
				childObj.name="child["+j+"]";
			childObj.transform.parent=parent.transform;
			CreatePos+=interval;
			if(childNum+1<child_type)
				childNum++;
			else
				childNum=0;
		}
		parent=null;
	}
}
