﻿#pragma checksum "..\..\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "00706C2EB9CCFE6F8BA55261B85DD88F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FEUHS_AMS;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace FEUHS_AMS {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid login_grid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginbtn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox username;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid setup_grid;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button setupbtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox db_username;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox db_password;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox db_host;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox db_dbname;
        
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
            System.Uri resourceLocater = new System.Uri("/FEUHS-AMS;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
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
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.login_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.loginbtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Login.xaml"
            this.loginbtn.Click += new System.Windows.RoutedEventHandler(this.login);
            
            #line default
            #line hidden
            return;
            case 4:
            this.username = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\Login.xaml"
            this.username.GotFocus += new System.Windows.RoutedEventHandler(this.textBox_clear);
            
            #line default
            #line hidden
            return;
            case 5:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 42 "..\..\Login.xaml"
            this.password.GotFocus += new System.Windows.RoutedEventHandler(this.PassWord_clear);
            
            #line default
            #line hidden
            return;
            case 6:
            this.setup_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.setupbtn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.db_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.db_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 10:
            this.db_host = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.db_dbname = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

