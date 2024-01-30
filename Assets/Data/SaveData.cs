using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static void SaveUserData(UserData data, string fileName)
    {
        var formatter = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + fileName);
        var secondData = new UserData();

        secondData.dropdownvalue = data.dropdownvalue;
        secondData.sensivityvalue = data.sensivityvalue;
        secondData.lightvalue = data.lightvalue;
        secondData.graficvalue = data.graficvalue;
        secondData.musicvalue = data.musicvalue;

        formatter.Serialize(file, data);
        file.Close();
    }
    public static UserData LoadUserData(string fileName)
    {
        var formatter = new BinaryFormatter();
        var file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
        var userData = (UserData) formatter.Deserialize(file);
        file.Close();

        var returnData = new UserData();
        returnData.dropdownvalue = userData.dropdownvalue;
        returnData.sensivityvalue = userData.sensivityvalue;
        returnData.lightvalue = userData.lightvalue;
        returnData.graficvalue = userData.graficvalue;
        returnData.musicvalue = userData.musicvalue;

        return userData;
    }

}
