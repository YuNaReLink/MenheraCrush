

namespace Kusume
{
    public enum ColorChangeType
    {
        TypeAlly,
        TypeEnemy
    }
    public interface IColorChanger
    {
        public CreatePieceMachine CreatePieceMachine {  get; }

        public ColorChangeType Type { get; }

        public void Execute();
    }
}
