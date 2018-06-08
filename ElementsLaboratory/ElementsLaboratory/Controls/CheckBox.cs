using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace ElementsLaboratory.Controls
{
    public class CheckBox : View
    {
        public static readonly BindableProperty IsCheckedProperty =
            BindablePropertyEx.Create<CheckBox, bool>(p => p.IsChecked, true, propertyChanged: (s, o, n) => { (s as CheckBox).OnChecked(new EventArgs()); });

        public static readonly BindableProperty ColorProperty =
            BindablePropertyEx.Create<CheckBox, Color>(p => p.Color, Color.Default);

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public event EventHandler Checked;

        protected virtual void OnChecked(EventArgs e)
        {
            if (Checked != null)
                Checked(this, e);
        }

        #region Solution to the warning of the Create method of the BindableProperty class
        internal static class BindablePropertyEx
        {
            public static BindableProperty Create<TDeclarer, TPropertyType>(Expression<Func<TDeclarer, TPropertyType>> getter,
                TPropertyType defaultValue,
                BindingMode defaultBindingMode = BindingMode.OneWay,
                BindableProperty.ValidateValueDelegate<TPropertyType> validateValue = null,
                BindableProperty.BindingPropertyChangedDelegate<TPropertyType> propertyChanged = null,
                BindableProperty.BindingPropertyChangingDelegate<TPropertyType> propertyChanging = null,
                BindableProperty.CoerceValueDelegate<TPropertyType> coerceValue = null,
                BindableProperty.CreateDefaultValueDelegate<TDeclarer, TPropertyType> defaultValueCreator = null) where TDeclarer : BindableObject
            {
                return BindableProperty.Create(ExpressionEx.GetPropertyPath(getter), typeof(TPropertyType), typeof(TDeclarer), defaultValue, defaultBindingMode,
                    validateValue: (bindable, value) => { return validateValue != null ? validateValue(bindable, (TPropertyType)value) : true; },
                    propertyChanged: (bindable, oldValue, newValue) => { if (propertyChanged != null) propertyChanged(bindable, (TPropertyType)oldValue, (TPropertyType)newValue); },
                    propertyChanging: (bindable, oldValue, newValue) => { if (propertyChanging != null) propertyChanging(bindable, (TPropertyType)oldValue, (TPropertyType)newValue); },
                    coerceValue: (bindable, value) => { return coerceValue != null ? coerceValue(bindable, (TPropertyType)value) : value; },
                    defaultValueCreator: (bindable) => { return defaultValueCreator != null ? defaultValueCreator((TDeclarer)bindable) : defaultValue; });
            }
        }

        internal static class ExpressionEx
        {
            public static string GetPropertyPath<T, P>(Expression<Func<T, P>> expression)
            {
                // Working outside in e.g. given p.Spouse.Name - the first node will be Name, then Spouse, then p
                IList<string> propertyNames = new List<string>();
                var currentNode = expression.Body;
                while (currentNode.NodeType != ExpressionType.Parameter)
                {
                    switch (currentNode.NodeType)
                    {
                        case ExpressionType.MemberAccess:
                        case ExpressionType.Convert:
                            MemberExpression memberExpression;
                            memberExpression = (currentNode.NodeType == ExpressionType.MemberAccess ? (MemberExpression)currentNode : (MemberExpression)((UnaryExpression)currentNode).Operand);
                            if (!(memberExpression.Member is PropertyInfo ||
                                    memberExpression.Member is FieldInfo))
                            {
                                throw new InvalidOperationException("The member '" + memberExpression.Member.Name + "' is not a field or property");
                            }
                            propertyNames.Add(memberExpression.Member.Name);
                            currentNode = memberExpression.Expression;
                            break;
                        case ExpressionType.Call:
                            MethodCallExpression methodCallExpression = (MethodCallExpression)currentNode;
                            if (methodCallExpression.Method.Name == "get_Item")
                            {
                                propertyNames.Add("[" + methodCallExpression.Arguments.First().ToString() + "]");
                                currentNode = methodCallExpression.Object;
                            }
                            else
                            {
                                throw new InvalidOperationException("The member '" + methodCallExpression.Method.Name + "' is a method call but a Property or Field was expected.");
                            }
                            break;

                        // To include method calls, remove the exception and uncomment the following three lines:
                        //propertyNames.Add(methodCallExpression.Method.Name);
                        //currentExpression = methodCallExpression.Object;
                        //break;
                        default:
                            throw new InvalidOperationException("The expression NodeType '" + currentNode.NodeType.ToString() + "' is not supported, expected MemberAccess, Convert, or Call.");
                    }
                }
                return string.Join(".", propertyNames.Reverse().ToArray());
            }
        }
        #endregion
    }
}