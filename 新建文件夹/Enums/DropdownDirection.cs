using System.ComponentModel;

namespace Klazor
{
    public enum DropdownDirection
    {
        Down,
        [Description("dropup")]
        Up,
        [Description("dropright")]
        Right,
        [Description("dropleft")]
        Left
    }
}
