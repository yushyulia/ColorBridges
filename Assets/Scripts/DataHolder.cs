using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "DataHolder", menuName = "ToolsForData/DataHolder", order = 1)]
public class DataHolder : ScriptableObject
{
    public DataItem dataItem;

    [SerializeField]
    private string filename = "save";
    private string FilePath => Path.Combine(Application.persistentDataPath, filename + ".json");

    public void SaveToFile()
    {
        string dataString = JsonUtility.ToJson(new DataSet(dataItem), true);
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }
        File.WriteAllText(FilePath, dataString);
    }

    public void LoadFromFile()
    {
        if (!File.Exists(FilePath))
        {
            return;
        }
        string dataString = File.ReadAllText(FilePath);

        dataItem = JsonUtility.FromJson<DataSet>(dataString).item;
    }
}

[System.Serializable]
public class DataItem
{
    public int level;
}

[System.Serializable]
public class DataSet
{
    public DataItem item;

    public DataSet(DataItem item)
    {
        this.item = item;
    }
}
