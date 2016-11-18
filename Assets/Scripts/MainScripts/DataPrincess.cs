using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class DataPrincess{
	//public static Achivements Names = new List<Achivements>();
	public static void Save(EnemyCreatorScript.GameLevels gameLevels ) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/GameLevels.io", FileMode.Create);
		bf.Serialize(file, gameLevels);
		file.Close();
	}

	public static EnemyCreatorScript.GameLevels LoadGameLevels() {
		if(File.Exists(Application.persistentDataPath + "/GameLevels.io")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/GameLevels.io", FileMode.Open);
			EnemyCreatorScript.GameLevels cham = (EnemyCreatorScript.GameLevels)bf.Deserialize(file);
			file.Close();
			return cham;
		}
		else
			return new EnemyCreatorScript.GameLevels();
	}


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