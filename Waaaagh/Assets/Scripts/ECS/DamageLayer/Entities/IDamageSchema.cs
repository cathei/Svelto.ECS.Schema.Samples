using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IDamageSchema
    {
        public Memo<IDamagableRow> Damaged { get; }
    }
}
