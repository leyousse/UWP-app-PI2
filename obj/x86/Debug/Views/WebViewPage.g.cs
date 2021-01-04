﻿#pragma checksum "C:\Users\leays\source\repos\Demoo\Views\WebViewPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EE62D48B27DAEDD5888EEFEF4BD8354AD7075FC8AF03CBB3173B8A005DB39D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demoo.Views
{
    partial class WebViewPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_WebView_Source(global::Windows.UI.Xaml.Controls.WebView obj, global::System.Uri value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Uri) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Uri), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(global::Windows.UI.Xaml.Controls.ProgressRing obj, global::System.Boolean value)
            {
                obj.IsActive = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class WebViewPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IWebViewPage_Bindings
        {
            private global::Demoo.Views.WebViewPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.WebView obj10;
            private global::Windows.UI.Xaml.Controls.StackPanel obj11;
            private global::Windows.UI.Xaml.Controls.StackPanel obj12;
            private global::Windows.UI.Xaml.Controls.ProgressRing obj13;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj10SourceDisabled = false;
            private static bool isobj11VisibilityDisabled = false;
            private static bool isobj12VisibilityDisabled = false;
            private static bool isobj13IsActiveDisabled = false;

            private WebViewPage_obj1_BindingsTracking bindingsTracking;

            public WebViewPage_obj1_Bindings()
            {
                this.bindingsTracking = new WebViewPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 84 && columnNumber == 35)
                {
                    isobj10SourceDisabled = true;
                }
                else if (lineNumber == 89 && columnNumber == 21)
                {
                    isobj11VisibilityDisabled = true;
                }
                else if (lineNumber == 95 && columnNumber == 21)
                {
                    isobj12VisibilityDisabled = true;
                }
                else if (lineNumber == 92 && columnNumber == 27)
                {
                    isobj13IsActiveDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 10: // Views\WebViewPage.xaml line 84
                        this.obj10 = (global::Windows.UI.Xaml.Controls.WebView)target;
                        break;
                    case 11: // Views\WebViewPage.xaml line 89
                        this.obj11 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 12: // Views\WebViewPage.xaml line 95
                        this.obj12 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 13: // Views\WebViewPage.xaml line 92
                        this.obj13 = (global::Windows.UI.Xaml.Controls.ProgressRing)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IWebViewPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Demoo.Views.WebViewPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Demoo.Views.WebViewPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::Demoo.ViewModels.WebViewViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Source(obj.Source, phase);
                        this.Update_ViewModel_IsLoadingVisibility(obj.IsLoadingVisibility, phase);
                        this.Update_ViewModel_FailedMesageVisibility(obj.FailedMesageVisibility, phase);
                        this.Update_ViewModel_IsLoading(obj.IsLoading, phase);
                    }
                }
            }
            private void Update_ViewModel_Source(global::System.Uri obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\WebViewPage.xaml line 84
                    if (!isobj10SourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_WebView_Source(this.obj10, obj, null);
                    }
                }
            }
            private void Update_ViewModel_IsLoadingVisibility(global::Windows.UI.Xaml.Visibility obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\WebViewPage.xaml line 89
                    if (!isobj11VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj11, obj);
                    }
                }
            }
            private void Update_ViewModel_FailedMesageVisibility(global::Windows.UI.Xaml.Visibility obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\WebViewPage.xaml line 95
                    if (!isobj12VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj12, obj);
                    }
                }
            }
            private void Update_ViewModel_IsLoading(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\WebViewPage.xaml line 92
                    if (!isobj13IsActiveDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(this.obj13, obj);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class WebViewPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<WebViewPage_obj1_Bindings> weakRefToBindingObj; 

                public WebViewPage_obj1_BindingsTracking(WebViewPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<WebViewPage_obj1_Bindings>(obj);
                }

                public WebViewPage_obj1_Bindings TryGetBindingObject()
                {
                    WebViewPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    WebViewPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Demoo.ViewModels.WebViewViewModel obj = sender as global::Demoo.ViewModels.WebViewViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_Source(obj.Source, DATA_CHANGED);
                                bindings.Update_ViewModel_IsLoadingVisibility(obj.IsLoadingVisibility, DATA_CHANGED);
                                bindings.Update_ViewModel_FailedMesageVisibility(obj.FailedMesageVisibility, DATA_CHANGED);
                                bindings.Update_ViewModel_IsLoading(obj.IsLoading, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Source":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Source(obj.Source, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsLoadingVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsLoadingVisibility(obj.IsLoadingVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "FailedMesageVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_FailedMesageVisibility(obj.FailedMesageVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsLoading":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsLoading(obj.IsLoading, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Demoo.ViewModels.WebViewViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::Demoo.ViewModels.WebViewViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 10: // Views\WebViewPage.xaml line 84
                {
                    this.webView = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\WebViewPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    WebViewPage_obj1_Bindings bindings = new WebViewPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

