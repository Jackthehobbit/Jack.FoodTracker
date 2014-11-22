using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    class CheckerService
    {
        public void notBlankCheck(string fieldName,string valueToCheck)
        {
            if(valueToCheck == "")
            {
                throw new ArgumentException(fieldName + " cannot be Blank");
            }
        }
        public void checkRecordExists<T>(IList<T> recordList,string propertyName,string value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression prop = Expression.PropertyOrField(parameter, propertyName);
            value = value.ToLower();
            MethodInfo method = typeof(string).GetMethod("ToLower",Type.EmptyTypes);
            prop = Expression.Call(prop, method);
            Expression body = Expression.Equal(prop, Expression.Constant(value));
            Expression<Func<T, Boolean>> lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            if (recordList.AsQueryable().Where(lambda).Any())
            {  
                throw new ArgumentException("A record with that " + propertyName.ToLower() + " already exists");
            }
        }
    }
}
