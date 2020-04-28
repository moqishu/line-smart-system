using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LINE.SMA.Infrastructure
{
    public class IocContainer2
    {
        private static IUnityContainer _myContainer;

        public static IUnityContainer MyContainer
        {
            get
            {
                if (_myContainer == null)
                {
                    _myContainer = new UnityContainer();
                }

                return _myContainer;
            }
        }

        public static T Resolve<T>() where T : class
        {
            try
            {
                return MyContainer.Resolve<T>();
            }
            catch (Exception ex)
            {
                LogUtils.ErrorLog(ex.ToString());
                return null;
            }
        }

        public static object Resolve(Type t, params ResolverOverride[] resolverOverrides)
        {
            return MyContainer.Resolve(t, resolverOverrides);
        }

        public static object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides)
        {
            return MyContainer.Resolve(t, name, resolverOverrides);
        }

        public static IUnityContainer RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            return MyContainer.RegisterType<TFrom, TTo>(lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// 默认容器管理单例模式
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public static IUnityContainer RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            return MyContainer.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// 自动注册
        /// </summary>
        public static void AutoRegister()
        {
            var classNames = GetAssembly();
            foreach (var item in classNames)
            {
                // 存在接口的注册方式
                if (item.Value.Length > 0)
                {
                    foreach (var typeArry in item.Value)
                    {
                        // 1.实例注册
                        MyContainer.RegisterType(typeArry, item.Key, new ExternallyControlledLifetimeManager());
                    }
                }
                else
                {
                    MyContainer.RegisterType(item.Key, new TransientLifetimeManager());
                }
            }
        }

        /// <summary>
        /// 获取目录程序集
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Type, Type[]> GetAssembly()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;

            //获取DLL文件
            List<string> files = Directory.GetFiles(directory, "*.dll").Select(path => Path.GetFileName(path)).ToList();
            files = files.Where(f => f.Contains("KT.SMA.")).ToList();

            List<Assembly> dllFiles = new List<Assembly>();
            foreach (var file in files)
            {
                dllFiles.Add(Assembly.Load(file.Replace(".dll", "")));
            }

            List<Type> types = new List<Type>();

            foreach (var item in dllFiles)
            {
                types.AddRange(item.GetTypes().Where(t => t.IsClass && !t.IsInterface && !t.IsAbstract));
            }

            Dictionary<Type, Type[]> result = new Dictionary<Type, Type[]>();
            foreach (var key in types)
            {
                var interfaceType = key.GetInterfaces();
                result.Add(key, interfaceType);
            }

            return result;
        }

        /// <summary>
        /// 获取目录程序集
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Type, Type[]> GetAssembly2()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            //directory = Path.Combine(directory, "Bin");
            string[] registerFiles = new string[]
            {
                "KT.SMA.Service.dll",
            };
            //获取DLL文件
            List<string> files = Directory.GetFiles(directory, "*.dll").Select(path => Path.GetFileName(path)).ToList();
            files = files.Where(f => registerFiles.Contains(f)).ToList();

            // 程序运行时程序集
            var dllFiles = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => files.Contains(assembly.ManifestModule.ScopeName)).ToList();

            List<Type> types = new List<Type>();

            foreach (var item in dllFiles)
            {
                types.AddRange(item.GetTypes().Where(t => t.IsClass && !t.IsInterface && !t.IsAbstract));
            }

            Dictionary<Type, Type[]> result = new Dictionary<Type, Type[]>();
            foreach (var key in types)
            {
                var interfaceType = key.GetInterfaces();
                result.Add(key, interfaceType);
            }

            return result;
        }
    }
}
