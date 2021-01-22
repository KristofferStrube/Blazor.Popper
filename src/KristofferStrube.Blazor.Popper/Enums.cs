using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    public enum Placement
    {
        [Description("auto")]
        Auto,
        [Description("auto-start")]
        AutoStart,
        [Description("auto-end")]
        AutoEnd,
        [Description("top")]
        Top,
        [Description("top-start")]
        TopStart,
        [Description("top-end")]
        TopEnd,
        [Description("bottom")]
        Bottom,
        [Description("bottom-start")]
        BottomStart,
        [Description("bottom-end")]
        BottomEnd,
        [Description("right")]
        Right,
        [Description("right-start")]
        RightStart,
        [Description("right-end")]
        RightEnd,
        [Description("left")]
        Left,
        [Description("left-start")]
        LeftStart,
        [Description("left-end")]
        LeftEnd
    }
    public enum Strategy
    {
        [Description("absolute")]
        Absolute,
        [Description("fixed")]
        Fixed
    }
}
