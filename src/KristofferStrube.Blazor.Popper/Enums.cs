using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.Popper
{
    [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
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

    [JsonConverter(typeof(EnumDescriptionConverter<Strategy>))]
    public enum Strategy
    {
        [Description("absolute")]
        Absolute,
        [Description("fixed")]
        Fixed
    }

    [JsonConverter(typeof(EnumDescriptionConverter<ModifierPhases>))]
    public enum ModifierPhases
    {
        [Description("beforeRead")]
        BeforeRead,
        [Description("read")]
        Read,
        [Description("afterRead")]
        AfterRead,
        [Description("beforeMain")]
        BeforeMain,
        [Description("main")]
        Main,
        [Description("afterMain")]
        AfterMain,
        [Description("beforeWrite")]
        BeforeWrite,
        [Description("write")]
        Write,
        [Description("afterWrite")]
        AfterWrite,
    }
}
