using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerData")]
public class PlayerDataBase : ScriptableObject
{
    [SerializeField] List<PlayerData> m_datas = new List<PlayerData>();
    public PlayerData GetData(int id) => m_datas[id];
}

[System.Serializable]
public class PlayerData
{ 
    
}

