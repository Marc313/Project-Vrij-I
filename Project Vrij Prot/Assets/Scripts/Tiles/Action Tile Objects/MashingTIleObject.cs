using UnityEngine;

public abstract class MashingTileObject : ActionTileObject
{
    public float MoveSpeed = 0.5f;
    public int MaxHealth;
    protected int health;

    [SerializeField] protected GameObject healthBarPrefab;
    protected RelationBar healthBar;

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

    private void StartHiveMashing()
    {
        health = MaxHealth;
        GameManager.Instance.StartHiveMovement(MoveSpeed);

        if (healthBarPrefab == null) return;
        healthBar = Instantiate(healthBarPrefab).GetComponentInChildren<RelationBar>();
        UIManager.Instance.UpdateTutorialText("MASH ENTER");
    }

    private void StopHiveMashing()
    {
        GameManager.Instance.StopHiveMovement();
        healthBar.gameObject.SetActive(false);
        this.enabled = false;
        UIManager.Instance.UpdateTutorialText("");
    }

    private float GetHealthRatio()
    {
        if (MaxHealth == 0) return 1;
        return (float)health / (float)MaxHealth;
    }

    private void OnHiveDestroyed()
    {
        UpdateRelationBars();
        gameObject.SetActive(false);
        StopHiveMashing();
        AudioManager.Instance.LowerPitch(0.01f);
        isObjectDestroyed = true;
    }

    public void DecreaseHealth()
    {
        health--;
        healthBar?.UpdateSliderValue(GetHealthRatio());

        if (health <= 0)
        {
            OnHiveDestroyed();
        }
    }
}