using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System;
public class DiaryParser : MonoBehaviour
{
  public Diary[] Parse(string _TSVFileName)
  {
    List<Diary> dialougeList = new List<Diary>(); //대사 리스트 생성
    TextAsset csvData = Resources.Load<TextAsset>(_TSVFileName); //TSV파일 가져옴

    string[] data = csvData.text.Split(new char[] { '\n' });

    for (int i = 1; i < data.Length;)
    {
      string[] row = data[i].Split(new char[] { '\t' });

      Diary diary = new Diary();//대사 리스트 생성

      diary.diaryNum = i;

      List<string> contextList = new List<string>();
      contextList.Add(row[1]);

      diary.contexts = contextList.ToArray();
      diary.diaryfeelNum = row[2];        

      dialougeList.Add(diary);

      if (++i > data.Length)
        break;
    }
    return dialougeList.ToArray();
  }
}
//#if UNITY_EDITOR
//[UnityEditor.AssetImporters.ScriptedImporter(1, "tsv")]
//public class TSVImporter : UnityEditor.AssetImporters.ScriptedImporter
//{
//  public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
//  {
//    TextAsset textAsset = new TextAsset(File.ReadAllText(ctx.assetPath));
//    ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), textAsset);
//    ctx.SetMainObject(textAsset);
//    AssetDatabase.SaveAssets();
//  }
//}
//#endif