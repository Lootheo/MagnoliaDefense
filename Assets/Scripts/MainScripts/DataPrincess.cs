using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class DataPrincess{
	//public static Achivements Names = new List<Achivements>();
	
	public static void Save(PrincessInfo cham) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/Princess.pd", FileMode.OpenOrCreate);
		bf.Serialize(file, cham);
		file.Close();
	}
	
	public static PrincessInfo Load() {
		if(File.Exists(Application.persistentDataPath + "/Princess.pd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Princess.pd", FileMode.Open);
			PrincessInfo cham = (PrincessInfo)bf.Deserialize(file);
			file.Close();
			return cham;
		}
		else
			return new PrincessInfo();
	}

	public static void Delete()
	{
		if(File.Exists(Application.persistentDataPath + "/Princess.pd")) {
			File.Delete(Application.persistentDataPath + "/Princess.pd");
		}
	}
}