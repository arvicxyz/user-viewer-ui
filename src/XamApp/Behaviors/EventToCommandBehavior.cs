﻿using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamApp.Behaviors
{
    public class EventToCommandBehavior : BindableBehavior<View>
    {
        public static BindableProperty EventNameProperty = BindableProperty.CreateAttached(
            propertyName: nameof(EventName),
            returnType: typeof(string),
            declaringType: typeof(EventToCommandBehavior),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public static BindableProperty CommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Command),
            returnType: typeof(ICommand),
            declaringType: typeof(EventToCommandBehavior),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public static BindableProperty CommandParameterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(CommandParameter),
            returnType: typeof(object),
            declaringType: typeof(EventToCommandBehavior),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public static BindableProperty EventArgsConverterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(EventArgsConverter),
            returnType: typeof(IValueConverter),
            declaringType: typeof(EventToCommandBehavior),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public static BindableProperty EventArgsConverterParameterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(EventArgsConverterParameter),
            returnType: typeof(object),
            declaringType: typeof(EventToCommandBehavior),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IValueConverter EventArgsConverter
        {
            get { return (IValueConverter)GetValue(EventArgsConverterProperty); }
            set { SetValue(EventArgsConverterProperty, value); }
        }

        public object EventArgsConverterParameter
        {
            get { return GetValue(EventArgsConverterParameterProperty); }
            set { SetValue(EventArgsConverterParameterProperty, value); }
        }

        protected Delegate _handler;
        private EventInfo _eventInfo;

        protected override void OnAttachedTo(View visualElement)
        {
            base.OnAttachedTo(visualElement);

            var events = AssociatedObject.GetType().GetRuntimeEvents().ToArray();
            if (events.Any())
            {
                _eventInfo = events.FirstOrDefault(e => e.Name == EventName);
                if (_eventInfo == null)
                    throw new ArgumentException(string.Format("EventToCommand: Can't find any event named '{0}' on attached type", EventName));

                AddEventHandler(_eventInfo, AssociatedObject, OnFired);
            }
        }

        protected override void OnDetachingFrom(View view)
        {
            if (_handler != null)
                _eventInfo.RemoveEventHandler(AssociatedObject, _handler);

            base.OnDetachingFrom(view);
        }

        private void AddEventHandler(EventInfo eventInfo, object item, Action<object, EventArgs> action)
        {
            var eventParameters = eventInfo.EventHandlerType
                .GetRuntimeMethods()
                .First(m => m.Name == "Invoke")
                .GetParameters()
                .Select(p => Expression.Parameter(p.ParameterType))
                .ToArray();

            var actionInvoke = action.GetType()
                .GetRuntimeMethods()
                .First(m => m.Name == "Invoke");

            _handler = Expression.Lambda(
                eventInfo.EventHandlerType,
                Expression.Call(Expression.Constant(action), actionInvoke, eventParameters[0], eventParameters[1]),
                eventParameters)
                .Compile();

            eventInfo.AddEventHandler(item, _handler);
        }

        private void OnFired(object sender, EventArgs eventArgs)
        {
            if (Command == null)
                return;

            var parameter = CommandParameter;

            if (eventArgs != null && eventArgs != EventArgs.Empty)
            {
                parameter = eventArgs;
                if (EventArgsConverter != null)
                {
                    parameter = EventArgsConverter.Convert(eventArgs, typeof(object), EventArgsConverterParameter, CultureInfo.CurrentUICulture);
                }
            }

            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }
    }
}
