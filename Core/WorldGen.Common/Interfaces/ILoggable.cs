using System;

namespace WorldGen.Common.Interfaces
{
    public abstract class ILoggable
    {
        protected string functionEnterBaseString = "{0}|{1}|Write function Enter|{2}|Parámetros : {3}";
        protected string functionExitBaseString = "{0}|{1}|Write function Exit|{2}";
        protected string functionErrorBaseString = "{0}|{1}|Write function Error|{2}|Exception Message : {3}";
        protected string functionMessageBaseString = "{0}|{1}|Write function enter|{2}|Message : {3}";
        

        protected abstract void WriteLogFunctionEnter(string fName, params object[] values);
        protected abstract void WriteLogFunctionExit(string fName, object result = null);
        protected abstract void WriteLogError(string fName, Exception ex);
        protected abstract void WriteLogMessage(string fName, string message);

        protected string GetArrayObjectsString(object[] values)
        {
            string result = String.Empty;
            Type objType;
            if(values == null || values.Length == 0)
            {
                result = "-";
            }
            else
            {
                foreach( object obj in values)
                {
                    objType =obj.GetType(); 
                    if(objType.GetMethod("ToString") != null)
                    {
                        result +=nameof(obj) + ":" + obj.ToString() + "#";
                    }
                    else
                    {
                        result +=nameof(obj) + ":" + obj + "#";
                    }
                }
            }

            return result;
        }

        protected string GetResultObjectString(object resultObject)
        {
            string result = String.Empty;

            if(resultObject != null)
            {
                if(resultObject.GetType().GetMethod("ToString") != null)
                {
                    result += "Result :" + resultObject.ToString() + "#";
                }
                else
                {
                    result += "Result :" + resultObject + "#";
                }
            }
            return result;
        }
    }
}