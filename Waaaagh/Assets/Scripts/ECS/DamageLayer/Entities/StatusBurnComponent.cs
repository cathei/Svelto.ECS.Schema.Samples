using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct StatusBurnComponent : IKeyComponent<bool>
    {
        public bool key { get => isBurning; set => isBurning = value; }

        public bool isBurning;
        public int burnDamage;

        public StatusBurnComponent(bool isBurning, int burnDamage) : this()
        {
            this.isBurning = isBurning;
            this.burnDamage = burnDamage;
        }
    }
}
