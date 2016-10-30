[System.Serializable]
public class PrincessInfo{
	public int gold;
	public bool fireShot;
	public bool iceShot;
	public bool bombShot;
	public bool ally1;
	public bool ally2;
	public bool ally3;
	public int unlockedLevels;
	public int NormalBulletCooldown;
	public int NormalBulletDamage;
	public int FireBulletCooldown;
	public int FireBulletDamage;
	public int IceBulletCooldown;
	public int IceBulletDamage;
	public int BombBulletCooldown;
	public int BombBulletDamage;
	public int CauldronDamage;
	public int CauldronCooldown;
	public float PlayerHP;


	public PrincessInfo () 
	{
		this.gold = 0;
		this.fireShot = false;
		this.iceShot = false;
		this.bombShot = false;
		this.ally1 = false;
		this.ally2 = false;
		this.ally3 = false;
		this.unlockedLevels = 0;
		this.NormalBulletDamage = 1;
		this.NormalBulletCooldown = 1;
		this.FireBulletDamage = 1;
		this.FireBulletCooldown = 1;
		this.IceBulletDamage = 1;
		this.IceBulletCooldown = 1;
		this.BombBulletDamage = 1;
		this.BombBulletCooldown = 1;
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