using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.AssetImporters; 
using UnityEditor;
using UnityEngine;
using System;

public class TalkingToSelfParser : MonoBehaviour
{

  public TalkingToSelf[] Parse(string _TSVFileName)
  {
    List<TalkingToSelf> dialougeList = new List<TalkingToSelf>(); //대사 리스트 생성
    TextAsset csvData = Resources.Load<TextAsset>(_TSVFileName); //TSV파일 가져옴

    string[] data = csvData.text.Split(new char[] { '\n' });

    for (int i = 1; i < data.Length;)
    {
      string[] row = data[i].Split(new char[] { '\t' });

      TalkingToSelf dialogue = new TalkingToSelf();//대사 리스트 생성

      dialogue.name = "GGom";

      List<string> contextList = new List<string>();
      contextList.Add(row[1]);

      dialogue.contexts = contextList.ToArray();

      dialougeList.Add(dialogue);
   
      if (++i > data.Length)
        break;
    }
    return dialougeList.ToArray();
  }
}

#if UNITY_EDITOR
[UnityEditor.AssetImporters.ScriptedImporter(1, "tsv")]
public class TSVImporter : UnityEditor.AssetImporters.ScriptedImporter
{
  public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
  {
    TextAsset textAsset = new TextAsset(File.ReadAllText(ctx.assetPath));
    ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), textAsset);
    ctx.SetMainObject(textAsset);
    AssetDatabase.SaveAssets();
  }
}
#endif