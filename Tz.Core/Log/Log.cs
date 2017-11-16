/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
namespace Tz.Core
{
    using System;
    using log4net;
    using System.Diagnostics;

    public  class Log
    {
        private ILog logger;
        public Log(ILog log)
        {
            logger = log;
        }
        public  void Debug(object message)
        {
            logger.Debug(message);
        }
        public  void Debug(object message,Exception ex)
        {
            logger.Debug(message,ex);
        }
        public  void Error(object message)
        {
            logger.Error(message);
        }
        public  void Error(object message, Exception ex)
        {
            logger.Error(message,ex);
        }
        public  void Info(object message)
        {
            logger.Info(message);
        }
        public  void Info(object message, Exception ex)
        {
            logger.Info(message,ex);
        }
        public  void Warn(object message)
        {
            logger.Warn(message);
        }
        public  void Warn(object message, Exception ex)
        {
            logger.Warn(message,ex);
        }

        private static string GetCurrentMethodFullName()
        {
            try
            {
                StackFrame frame;
                string str2;
                int num = 2;
                StackTrace trace = new StackTrace();
                int length = trace.GetFrames().Length;
                do
                {
                    frame = trace.GetFrame(num++);
                    str2 = frame.GetMethod().DeclaringType.ToString();

                } while (str2.EndsWith("Excption") && (num < length));
                string name = frame.GetMethod().Name;
                return (str2 + "." + name);
            }
            catch (Exception)
            {
                return System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();
            }
        }
    }
}
