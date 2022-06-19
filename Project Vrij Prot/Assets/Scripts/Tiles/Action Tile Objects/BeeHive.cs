using UnityEngine;

public class BeeHive : ActionTileObject
{
    public float MoveSpeed = 0.5f;
    public int MaxHealth;
    private int health;

    [SerializeField] private GameObject beeHealthBarPrefab;
    private RelationBar beeHealthBar;

    public override void OnTileEnter()
    {
        StartHiveMashing();
    }

    public override void OnTileExit()
    {
        StopHiveMashing();
    }

    public override void TriggerTileObject()
    {
        DecreaseHealth();
    }

    public override void UpdateRelationBars()
    {
        RelationBarManager.Instance.IncreaseCultScore(-0.25f);
        RelationBarManager.Instance.IncreaseOmgevingScore(-0.1f);
        RelationBarManager.Instance.IncreaseBoomMachtScore(0.1f);
    }

    private void StartHiveMashing()
    {
        health = MaxHealth;
        GameManager.Instance.StartHiveMovement(MoveSpeed);

        if (beeHealthBarPrefab == null) return;
        beeHealthBar = Instantiate(beeHealthBarPrefab).GetComponentInChildren<RelationBar>();
    }

    private void StopHiveMashing()
    {
        GameManager.Instance.StopHiveMovement();
        beeHealthBar.gameObject.SetActive(false);
        this.enabled = false;
    }

    private float GetHealthRatio()
    {
        if(MaxHealth == 0) return 1;
        return (float) health / (float) MaxHealth;
    }

    private void OnHiveDestroyed()
    {
        UpdateRelationBars();
        gameObject.SetActive(false);
        StopHiveMashing();
    }

    public void DecreaseHealth()
    {
        health--;
        beeHealthBar?.UpdateSliderValue(GetHealthRatio());

        if(health <= 0)
        {
            OnHiveDestroyed();
        }
    }
}