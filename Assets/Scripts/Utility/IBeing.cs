public interface IBeing
{
    int Health
    {
        get;
        set;
    }

    void TakeDamage(float amount);
}
