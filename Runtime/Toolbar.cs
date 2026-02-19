using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace QuickEye.DarkTheme
{
    [UxmlElement]
    public partial class Toolbar : VisualElement
    {
        private static readonly StyleSheet _ToolbarDarkStyleSheet;
        public static readonly string ussClassName = "unity-toolbar";

        static Toolbar()
        {
            _ToolbarDarkStyleSheet = Resources.Load<StyleSheet>("com.quickeye.dark-runtime-theme/Toolbar Dark");
        }

        public Toolbar()
        {
            AddToClassList(ussClassName);
            SetToolbarStyleSheet(this);
        }

        public static void SetToolbarStyleSheet(VisualElement ve)
        {
            ve.styleSheets.Add(_ToolbarDarkStyleSheet);
        }
    }

    [UxmlElement]
    public partial class ToolbarToggle : Toggle
    {
        public new static readonly string ussClassName = "unity-toolbar-toggle";

        public ToolbarToggle()
        {
            focusable = false;

            Toolbar.SetToolbarStyleSheet(this);
            RemoveFromClassList(Toggle.ussClassName);
            AddToClassList(ussClassName);
        }
    }

    [UxmlElement]
    public partial class ToolbarButton : Button
    {
        public new static readonly string ussClassName = "unity-toolbar-button";

        public ToolbarButton(Action clickEvent) : base(clickEvent)
        {
            Toolbar.SetToolbarStyleSheet(this);
            RemoveFromClassList(Button.ussClassName);
            AddToClassList(ussClassName);
        }

        public ToolbarButton() : this(() => { })
        {
        }
    }
}