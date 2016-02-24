using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
/// <summary>
/// Make stage.
/// 下のようなCSVデータからステージ生成をしたいと思ったので作ってみる。
/// 壁の繋がってる部分は、CubeのScaleを変えて対応する。
/// Sample.csv
/// 壁,壁,壁,壁,壁,壁
/// 壁,　,　,　,壁,壁
/// 壁,　,壁,　,　,壁
/// 壁,壁,壁,壁,壁,壁
/// </summary>
class makeStage : EditorWindow {
	private TextAsset stageData;
	private float StageScale=1f;
	private string[] beforeWalls;
	private int wallWidth;//横列で読む
	private int WidthNum;
	private int[] wallHeight;//縦列で読む
	private int HeightNum;
	private bool makingStage=false;
	private GameObject Stage;
	[MenuItem ("Origin/makeStage")]
	
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(makeStage));
	}
	void OnGUI() {
		try {
			GUILayout.Label("Stage: ", EditorStyles.boldLabel);
			stageData = EditorGUILayout.ObjectField("data", stageData, typeof(TextAsset), true) as TextAsset;
			StageScale = int.Parse(EditorGUILayout.TextField("Scale", StageScale.ToString()));
			if (GUILayout.Button("Create")) stageCreator();
		} catch (System.FormatException) {}
	}
	void stageCreator()
	{
		if (stageData == null)
			return;
		StringReader reader = new StringReader (stageData.text);
		int height = 0;
		while (reader.Peek()>-1) {
			string body = reader.ReadLine ();
			string[] values = body.Split (',');
			if(!makingStage)
			{
				Stage=GameObject.CreatePrimitive(PrimitiveType.Plane);
				Stage.transform.localScale=new Vector3(StageScale,1,StageScale);
				beforeWalls=new string[values.Length];
				wallHeight=new int[values.Length];
				makingStage = true;
			}
			for(int i=0;i<values.Length;i++)
			{
				getWallData(i,values[i],values.Length,height);
			}
			height++;
		}
		makingStage = false;
	}
	void getWallData(int i,string data,int width,int height)
	{
		if (beforeWalls [i] == null) {//一行目
			wallHeight[i]=1;
		}
		beforeWalls [i] = data;
		if (data == "Wall") {
			//height
			if (beforeWalls [i] == "Wall") {
				wallHeight[i]++;
			} else {
				wallHeight[i] = 1;
			}
			//width
			if(i==0)
			{
				wallWidth=1;
			}else if(beforeWalls[i-1]=="Wall")
			{
				wallWidth++;
			}else
			{
				wallWidth=1;
			}
			WidthNum=i;
			if(i+1==width&&wallWidth!=1)//端に来たら生成
			{
				GameObject newWall=GameObject.CreatePrimitive(PrimitiveType.Cube);
				newWall.transform.parent=Stage.transform;
				float newWallWidth=(float)(wallWidth)/(float)(width)*10;
				newWall.transform.localScale=new Vector3(newWallWidth,1,1/StageScale);
				if(height==0)
				{
					newWall.transform.localPosition=new Vector3(0f,0.5f,5f);
				}
				if(height==6)
				{
					newWall.transform.localPosition=new Vector3(0,0.5f,-5f);
				}
			}

		} else {
			if(beforeWalls[i]=="Wall")
			{


			}
		}

	}
}
