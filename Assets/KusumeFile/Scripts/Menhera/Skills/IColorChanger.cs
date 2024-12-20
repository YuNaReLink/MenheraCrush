

namespace Kusume
{
    public enum ColorChangeType
    {
        TypeAlly,
        TypeEnemy
    }
    public interface IColorChanger
    {

        public ColorChangeType Type { get; }

        public void Execute();
    }
}
