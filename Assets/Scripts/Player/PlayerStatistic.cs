using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    public static PlayerStatistic Instance;
    private float life;
    public float Life { get { return life; } set { life = Mathf.Clamp(value, 0, 100); } }
    public int AttackMelee { get; set; }
    public int AttackDistance { get; set; }
    public int Armor_Helmet { get; set; }
    public int Armor_Chestplate { get; set; }
    public int TotalArmor { get { return Armor_Chestplate + Armor_Helmet; } }
    public float MoveSpeed { get; set; } = 1;

    void Awake() { Instance = this; }
}
