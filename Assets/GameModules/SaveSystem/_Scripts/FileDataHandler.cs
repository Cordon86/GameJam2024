using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;                    // https://learn.microsoft.com/en-us/dotnet/api/system.io?view=net-8.0

/*      TIL
 *      https://www.c-sharpcorner.com/UploadFile/manas1/usage-and-importance-of-using-in-C-Sharp472/
 */

public class FileDataHandler
{
    private string dataPath = "";
    private string dataFile = "";

    // This constructor is generally called from the SaveManager Start() method.
    public FileDataHandler(string _dataPath, string _dataFile)
    {
        this.dataPath = _dataPath;
        this.dataFile = _dataFile;
    }


    public void Save(GameData _data)
    {
        string _fullPath = Path.Combine(dataPath, dataFile);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_fullPath));// ?? throw new InvalidOperationException());

            string _dataToWrite = JsonUtility.ToJson(_data, true);

            using (FileStream _stream = new FileStream(_fullPath, FileMode.Create))
            {
                using (StreamWriter _writer = new StreamWriter(_stream))
                {
                    _writer.Write(_dataToWrite);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Error while creating file \n" + e);
            throw;
        }
        
    }

    public GameData Load()
    {
        string _fullPath = Path.Combine(dataPath, dataFile);
        GameData _loadData = null;
        
        if (File.Exists(_fullPath))
        {
            try
            {
                string _dataToLoad = "";
                using(FileStream _stream = new FileStream(_fullPath, FileMode.Open))
                {
                    using (StreamReader _reader = new StreamReader(_stream))
                    {
                        _dataToLoad = _reader.ReadToEnd();
                    }
                }

                _loadData = JsonUtility.FromJson<GameData>(_dataToLoad);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return _loadData;
    }
    
    
    
    
}
