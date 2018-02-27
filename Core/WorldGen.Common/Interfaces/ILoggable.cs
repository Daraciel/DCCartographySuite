using System;
using System.Reflection;

namespace WorldGen.Common.Interfaces
{
    public abstract class ILoggable
    {
        protected string functionEnterBaseString = "{0}|{1}|Write function Enter|{2}|Parámetros : {3}";
        protected string functionExitBaseString = "{0}|{1}|Write function Exit|{2}";
        protected string functionErrorBaseString = "{0}|{1}|Write function Error|{2}|Exception Message : {3}";
        protected string functionMessageBaseString = "{0}|{1}|Write function enter|{2}|Message : {3}";
        

        protected abstract void WriteLogFunctionEnter(MethodBase method, params object[] values);
        protected abstract void WriteLogFunctionExit(MethodBase method, object result = null);
        protected abstract void WriteLogError(MethodBase method, Exception ex);
        protected abstract void WriteLogMessage(MethodBase method, string message);
        protected abstract void WriteLogMessage(string message);

        protected string GetArrayObjectsString(MethodBase method, params object[] values)
        {
            string result = String.Empty;
            Type objType;
            MethodInfo methodToString;
            string objName;
            string valueToString;
            if(values == null || values.Length == 0)
            {
                result = "-";
            }
            else
            {
                for(int i=0; i<values.Length; i++)
                //foreach( object myObj in values)
                {
                    objName = GetParamName(method, i);
                    objType = values[i].GetType();
                    methodToString = objType.GetMethod(
                                                        "ToString",
                                                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly,
                                                        null,
                                                        new Type[] { },// Method ToString() without parameters
                                                        null);
                    if(methodToString != null)
                    {
                        //this.WriteLogMessage("GetArrayObjectsString", "nameof(obj): " + objName);
                        //this.WriteLogMessage("GetArrayObjectsString", "obj.GetType().GetMethod('ToString').Invoke(obj, null): " + methodToString.Invoke(values[i], null));
                        valueToString = (string)methodToString.Invoke(values[i], null);
                        result += objName + ":" + valueToString + "#";
                    }
                    else
                    {
                        result += objName + ":" + "NOT STRINGGABLE" + "#";
                    }
                }
            }

            return result;
        }

        protected string GetResultObjectString(MethodBase method, object resultObject)
        {
            string result = String.Empty;
            Type objType;
            MethodInfo methodToString;
            string valueToString;

            if(resultObject != null)
            {
                 objType = resultObject.GetType();
                 methodToString = objType.GetMethod("ToString",
                                                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly,
                                                    null,
                                                    new Type[] { },// Method ToString() without parameters
                                                    null);
                if(methodToString != null)
                {
                    valueToString = (string)methodToString.Invoke(resultObject, null);
                    result += "Result :" + valueToString;
                }
                else
                {
                    result += "Result :" + "NOT STRINGGABLE" + "#";
                }
            }
            return result;
        }

        protected string GetParamName(MethodBase method, int index)
        {
            string retVal = string.Empty;

            if (method != null && method.GetParameters().Length > index)
                retVal = method.GetParameters()[index].Name;


            return retVal;
        }
    }
}