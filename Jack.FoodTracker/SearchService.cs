using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public class SearchService
    {
        private readonly Regex comparisonRegex = new Regex("(.*?)(<=|>=|=>|=<|!=|=|<|>)(.*)");

        public void ConvertComparison(String searchText, out String key, out String exp, out String val)
        {
            Match matches = comparisonRegex.Match(searchText);
            key = matches.Groups[1].Value;
            exp = matches.Groups[2].Value;
            val = matches.Groups[3].Value;

            if (key == null || exp == null || val == null)
            {
                throw new ArgumentException("Error when searching");
            }
        }

        public IList<T> ApplySearchNumerical<T, TNumeric>(IList<T> searchList, string propertyName, string expression, TNumeric value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression prop = Expression.PropertyOrField(parameter, propertyName);
            Expression body;

            switch (expression)
            {
                case "=":
                    body = Expression.Equal(prop, Expression.Constant(value));
                    break;
                case ">":
                    body = Expression.GreaterThan(prop, Expression.Constant(value));
                    break;
                case "<":
                    body = Expression.LessThan(prop, Expression.Constant(value));
                    break;
                case "<=":
                case "=<":
                    body = Expression.LessThanOrEqual(prop, Expression.Constant(value));
                    break;
                case ">=":
                case "=>":
                    body = Expression.GreaterThanOrEqual(prop, Expression.Constant(value));
                    break;
                case "!=":
                    body = Expression.NotEqual(prop, Expression.Constant(value));
                    break;
                default:
                    throw new ArgumentException(expression + "is not a valid search expression for " + propertyName);
            }

            Expression<Func<T, Boolean>> lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return searchList.AsQueryable().Where(lambda).ToList();
        }

        public IList<T> ApplySearchEquals<T>(IList<T> searchList, string propertyName, string expression, object value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression prop = Expression.PropertyOrField(parameter, propertyName);
            Expression body;

            if(expression == "!=")
            {
                body = Expression.NotEqual(prop, Expression.Constant(value));
            }
            else
            {
                body = Expression.Equal(prop, Expression.Constant(value));
            }

            Expression<Func<T, Boolean>> lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return searchList.AsQueryable().Where(lambda).ToList();
        }

        public IList<T> ApplySearchEquals<T>(IList<T> searchList, string propertyName, string expression, string value, bool lowerCase)
        {
            

            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression prop = Expression.PropertyOrField(parameter, propertyName);

            if(lowerCase)
            {
                value = value.ToLower();

                MethodInfo method = typeof(string).GetMethod("ToLower");
                prop = Expression.Call(prop, method);
            }

            Expression body;

            if (expression == "!=")
            {
                body = Expression.NotEqual(prop, Expression.Constant(value));
            }
            else
            {
                body = Expression.Equal(prop, Expression.Constant(value));
            }

            Expression<Func<T, Boolean>> lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return searchList.AsQueryable().Where(lambda).ToList();
        }

        public IList<T> ApplySearchContains<T>(IList<T> searchList, string propertyName, string expression, string value, bool lowerCase)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression prop = Expression.PropertyOrField(parameter, propertyName);
            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            Expression body;

            if (lowerCase)
            {
                value = value.ToLower();

                MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
                prop = Expression.Call(prop, toLowerMethod);
            }

            if (expression == "!=")
            {
                body = Expression.Not(Expression.Call(prop, containsMethod, Expression.Constant(value)));
            }
            else
            {
                body = Expression.Call(prop, containsMethod, Expression.Constant(value));
            }


            Expression<Func<T, Boolean>> lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return searchList.AsQueryable().Where(lambda).ToList();
        }
    }
}
