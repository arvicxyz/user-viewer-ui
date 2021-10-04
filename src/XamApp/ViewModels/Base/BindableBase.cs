using System;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public abstract class BindableBase : BindableObject
    {
        public object GetPropertyValue(string propertyName)
        {
            return GetType().GetProperty(propertyName).GetValue(this, null);
        }

        public T GetPropertyValue<T>(string propertyName)
        {
            var value = GetPropertyValue(propertyName);
            return (T)Convert.ChangeType(value, typeof(T));
        }

        protected void SetProperty<T>(ref T item, T value, string property)
        {
            if (item == null)
                item = default;

            if (item == null || !item.Equals(value))
            {
                item = value;
                RaisePropertyChanged(property);
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private static MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            var lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body is UnaryExpression body)
            {
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }
}
