using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {
    public GameInfo gameInfo;
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            gameInfo = (GameInfo)bf.Deserialize(file);
            file.Close();
            gameInfo.partyMembers[0].RetrieveInfo(PlayerManager.instance.player.GetComponent<PartyStats>());
            gameInfo.partyMembers[1].RetrieveInfo(AIManager.instance.partyAllies[0].GetComponent<PartyStats>());
            gameInfo.partyMembers[2].RetrieveInfo(AIManager.instance.partyAllies[1].GetComponent<PartyStats>());

        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd"); //you can call it anything you want
        gameInfo.partyMembers[0].FillInfo(PlayerManager.instance.player.GetComponent<PartyStats>());
        Debug.Log(gameInfo.partyMembers[0].position);
        gameInfo.partyMembers[1].FillInfo(AIManager.instance.partyAllies[0].GetComponent<PartyStats>());
        Debug.Log(gameInfo.partyMembers[1].position);
        gameInfo.partyMembers[2].FillInfo(AIManager.instance.partyAllies[1].GetComponent<PartyStats>());
        Debug.Log(gameInfo.partyMembers[2].position);
        bf.Serialize(file, gameInfo);
        file.Close();
    }
    
    
}
[System.Serializable]
public class GameInfo
{
    public CharacterInfo[] partyMembers = new CharacterInfo[3];
}
[System.Serializable]
public class CharacterInfo
{
    public int maxHealth = 100;
    public int maxStamina = 100;
    public int currentHealth;
    public int currentXp = 0;
    public int currentlvl = 1;
    public int nextLevelXp = 100;
    public int skillPoints = 0;
    public Stat damage;
    public Stat armor;
    public float[] position = new float[3];

    public void FillInfo(PartyStats characterStats)
    {
        maxHealth = characterStats.maxHealth;
        maxStamina = characterStats.maxStamina;
        currentHealth = characterStats.currentHealth;
        currentXp = characterStats.currentXp;
        currentlvl = characterStats.currentlvl;
        nextLevelXp = characterStats.nextLevelXp;
        skillPoints = characterStats.nextLevelXp;
        damage = characterStats.damage;
        armor = characterStats.armor;
        Vector3ToVector(characterStats.GetComponent<Transform>().position);

}
    public void RetrieveInfo(PartyStats characterStats)
    {
        characterStats.maxHealth = maxHealth ;
        characterStats.maxStamina = maxStamina;
        characterStats.currentHealth = currentHealth ;
        characterStats.currentXp = currentXp;
        characterStats.currentlvl = currentlvl;
        characterStats.nextLevelXp = nextLevelXp;
        characterStats.nextLevelXp = skillPoints;
        characterStats.damage = damage;
        characterStats.armor = armor;
        characterStats.GetComponent<Transform>().position = VectorToVector3(position);
    }
    public void Vector3ToVector(Vector3 vector3)
    {
        position[0] = vector3.x;
        position[1] = vector3.y;
        position[2] = vector3.z;
    }
    public Vector3 VectorToVector3(float[] position)
    {
        Vector3 VectorPosition = new Vector3
        {
            x = position[0],
            y = position[1],
            z = position[2]
        };
        return VectorPosition;
    }
}