using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    public static PlayerStatistic Instance;
    private int life;
    public int Life { get { return life; } set { life = Mathf.Clamp(value, 0, 100); } }
    public int Attack { get; set; }
    public int Armor { get; set; }
    public float MoveSpeed { get; set; }

    void Awake() { Instance = this; }
}
