//for defending core

namespace CoreBreach.Interfaces
{
    public interface IObjective
    {
        float CurrentHealth { get; }
        float MaxHealth { get; }
        bool IsDestroyed { get; }
    }
}