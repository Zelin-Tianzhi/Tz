/*******************************************************************************
 * Copyright © 2017 Zl 版权所有
 * Author: Zl
 * Description: Tz通用权限
*********************************************************************************/
using System;
using log4net;

namespace Tz.Core
{
    public class Log
    {
        private static ILog logger;
        public Log(ILog log)
        {
            logger = log;
        }
        public static void Debug(object message)
        {
            logger.Debug(message);
        }
        public void Debug(object message,Exception ex)
        {
            logger.Debug(message,ex);
        }
        public void Error(object message)
        {
            logger.Error(message);
        }
        public void Error(object message, Exception ex)
        {
            logger.Error(message,ex);
        }
        public void Info(object message)
        {
            logger.Info(message);
        }
        public void Info(object message, Exception ex)
        {
            logger.Info(message,ex);
        }
        public void Warn(object message)
        {
            logger.Warn(message);
        }
        public void Warn(object message, Exception ex)
        {
            logger.Warn(message,ex);
        }
    }
}
