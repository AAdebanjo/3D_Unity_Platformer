using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Difficulty", order = 1)]
public class DifficultySettings : ScriptableObject
{
    public float healthDropChance = 0.25f;
    public float bossSpawnChance = 0.25f;
    public float legendaryItemChance = 0.02f;
    public float enemyEssenseFillRate = 0.1f;
}
