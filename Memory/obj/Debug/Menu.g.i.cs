﻿#pragma checksum "..\..\Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97FB9F523F23F1E2BAB44A25C6E802D0D67A9934DF9EDF74E5903C497CE95D0B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Memory;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Memory {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newGame;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openGame;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button statistics;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Options;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button standard;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button custom;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider CustomHeight;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textHeight;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider CustomWidth;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textWidth;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Play;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button about;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Memory;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.newGame = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Menu.xaml"
            this.newGame.Click += new System.Windows.RoutedEventHandler(this.new_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.openGame = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Menu.xaml"
            this.openGame.Click += new System.Windows.RoutedEventHandler(this.open_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.statistics = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Menu.xaml"
            this.statistics.Click += new System.Windows.RoutedEventHandler(this.stats_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Options = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.standard = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\Menu.xaml"
            this.standard.Click += new System.Windows.RoutedEventHandler(this.standard_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.custom = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Menu.xaml"
            this.custom.Click += new System.Windows.RoutedEventHandler(this.custom_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CustomHeight = ((System.Windows.Controls.Slider)(target));
            return;
            case 8:
            this.textHeight = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.CustomWidth = ((System.Windows.Controls.Slider)(target));
            return;
            case 10:
            this.textWidth = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Play = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\Menu.xaml"
            this.Play.Click += new System.Windows.RoutedEventHandler(this.play_click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.about = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\Menu.xaml"
            this.about.Click += new System.Windows.RoutedEventHandler(this.about_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

