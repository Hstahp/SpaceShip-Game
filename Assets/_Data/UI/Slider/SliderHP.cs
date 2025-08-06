using UnityEngine;
using UnityEngine.UI;

public  class SliderHP : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP = 70f;
    protected override void FixedUpdate()
    {
        this.HPShowing();
    }
    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
        //Debug.Log("newValue:" + newValue);
    }
    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHP(float currentMaxHP)
    {
        this.currentHP = currentMaxHP;
    }
}
