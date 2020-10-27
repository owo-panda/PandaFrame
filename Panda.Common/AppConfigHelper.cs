﻿using System;
using Microsoft.Extensions.Configuration;

namespace Panda.Common
{
    public class AppConfigHelper
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static IConfiguration Configuration { get; private set; }

        /// <summary>
        /// 依赖注入对象提供器
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// 获得配置文件的对象值
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJson(string jsonPath, string key)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(jsonPath).Build(); //json文件地址
            string s = config.GetSection(key).Value; //json某个对象
            return s;
        }
        public static void SetServiceProvider(IServiceProvider provider)
        {
            ServiceProvider = provider;
        }

        public static void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
