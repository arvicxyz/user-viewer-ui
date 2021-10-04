using System;
using System.Globalization;
using System.Reflection;
using DryIoc;
using XamApp.Core;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached(
            propertyName: "AutoWireViewModel",
            returnType: typeof(bool),
            declaringType: typeof(ViewModelLocator),
            defaultValue: default(bool),
            propertyChanged: OnAutoWireViewModelChanged
        );

        public static bool GetAutoWireViewModel(BindableObject bindable)
            => (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
            => bindable.SetValue(AutoWireViewModelProperty, value);

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
            => IocManager.Container.Register<TInterface, T>(Reuse.Singleton);

        public static T Resolve<T>() where T : class
            => IocManager.Container.Resolve<T>();

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            var viewType = view?.GetType();
            if (viewType?.FullName == null)
            {
                return;
            }

            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = IocManager.Container.Resolve(viewModelType, true);
            var baseViewModel = viewModel as BaseViewModel;
            if (baseViewModel != null)
            {
                baseViewModel.Page = view as Page;
                baseViewModel.Navigation = baseViewModel.Page?.Navigation;
            }
            view.BindingContext = baseViewModel ?? viewModel;
        }
    }
}
