[System.Serializable]
public class PrincessInfo{
	public int gold;
	public int fireShot;
	public int iceShot;
	public int bombShot;
	public int ally1;
	public int ally2;
	public int ally3;
	public int unlockedLevels;
	public float BulletCooldown;
	public float BulletSpeed;
	public float BulletTravelTime;
	public float CauldronDamage;
	public float CauldronCooldown;
	public float PlayerHP;


	public PrincessInfo () {
		this.gold = 0;
		this.fireShot = 0;
		this.iceShot = 0;
		this.bombShot = 0;
		this.ally1 = 0;
		this.ally2 = 0;
		this.ally3 = 0;
		this.unlockedLevels = 0;
		this.BulletCooldown = 0;
		this.BulletSpeed = 0;
		this.BulletTravelTime = 0;
		this.CauldronDamage = 0;
		this.CauldronCooldown = 0;
		this.PlayerHP = 100;
	}
}

[System.Serializable]
public class LevelData
{
	public int Score;
	public int Waves;
	public int EnemysPerWave;
	public float EnemyTime;
	public float WaveTime;

	public LevelData()
	{
		this.Score = 0;
		this.Waves = 0;
		this.EnemysPerWave = 0;
		this.EnemyTime = 0;
		this.WaveTime = 0;
	}
}