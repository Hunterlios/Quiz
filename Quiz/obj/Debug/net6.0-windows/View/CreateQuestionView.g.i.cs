﻿#pragma checksum "..\..\..\..\View\CreateQuestionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13B8403A334C1E2B26F361717B7305BA6F7BB36C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Quiz.View {
    
    
    /// <summary>
    /// CreateQuestionView
    /// </summary>
    public partial class CreateQuestionView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox theQuestionTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox answerATextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox answerBTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox answerCTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox answerDTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox answerComboBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextQuestionCreateButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\View\CreateQuestionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button previousQuestionCreateButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Quiz;component/view/createquestionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\CreateQuestionView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.theQuestionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.answerATextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.answerBTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.answerCTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.answerDTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.answerComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.nextQuestionCreateButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.previousQuestionCreateButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

