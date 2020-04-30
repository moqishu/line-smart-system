using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

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
            List<Assembly> assemblys = LoadAssembly();

            List<Type> classTypes = GetClassTypes(assemblys);

            RegisterType<ExternallyControlledLifetimeManager>(classTypes);

            //实现ISingleton接口的类型集合注册为单例模式
            List<Type> singletonTypeList = GetDerivedClass<ISingleton>(classTypes);
            //注册单例
            RegisterType<ContainerControlledLifetimeManager>(singletonTypeList);
        }

        /// <summary>
        /// 从指定的类型集合中过滤出从指定类或接口派生的类
        /// </summary>
        /// <typeparam name="T">基类或接口</typeparam>
        /// <param name="classTypes">类型集合</param>
        /// <returns></returns>
        private static List<Type> GetDerivedClass<T>(List<Type> classTypes) where T : class
        {
            return classTypes.AsParallel().Where(t => t.GetInterface(typeof(T).ToString()) != null).ToList();
        }

        /// <summary>
        /// 从程序集加载所有类(不包含接口、抽象类)
        /// </summary>
        /// <param name="assemblys"></param>
        /// <returns></returns>
        private static List<Type> GetClassTypes(List<Assembly> assemblys)
        {
            List<Type> types = new List<Type>();
            assemblys.ForEach(assembly =>
            {
                try
                {
                    types.AddRange(assembly.GetTypes().Where(t => t.IsClass && !t.IsInterface && !t.IsAbstract));
                }
                catch (ReflectionTypeLoadException ex)
                {
                    //处理类型加载异常，一般为缺少引用的程序集导致
                }

            });
            return types;
        }

        /// <summary>
        /// 获取类型的所有集成、实现的接口抽象类
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static List<Type> GetBaseTypes(Type classType)
        {
            HashSet<string> ignoreInterface = new HashSet<string>
            {
                typeof(EntityBase).ToString()
            };
            List<Type> baseTypes = classType.GetInterfaces().Where(t => !IsSystemNamespace(t.Namespace) && !ignoreInterface.Contains(t.FullName)).ToList();
            GetAbstructTypes(classType, baseTypes);
            return baseTypes;
        }

        /// <summary>
        /// 获取类型所有的抽象基类
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="abstructTypes"></param>
        public static void GetAbstructTypes(Type classType, List<Type> abstructTypes)
        {
            Type baseType = classType.BaseType;
            if (baseType != typeof(object) && baseType.IsAbstract && !IsSystemNamespace(baseType.Namespace))
            {
                abstructTypes.Add(baseType);
                GetAbstructTypes(baseType, abstructTypes);
            }
        }

        /// <summary>
        /// 判断接口或抽象类是否为系统的命名空间
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        private static bool IsSystemNamespace(string ns)
        {
            //常用系统命名空间
            HashSet<string> sysNamespace = new HashSet<string>
            {
                "Microsoft.Xml",
                "System",
                "System.Collections",
                "System.ComponentModel",
                "System.Configuration",
                "System.Data",
                "System.IO",
                "System.Runtime",
                "System.ServiceModel",
                "System.Text",
                "System.Web",
                "System.Xml"
            };
            return sysNamespace.Contains(string.Join(".", ns.Split('.').Take(2)));
        }

        /// <summary>
        /// 获取指定目录及其子目录的所有DLL文件路径集合
        /// </summary>
        /// <param name="assemblyDirectory"></param>
        /// <returns></returns>
        private static List<string> GetAssemblyFiles()
        {
            string assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (HttpContext.Current != null)
            {
                assemblyDirectory = Path.Combine(assemblyDirectory, "Bin");
            }
            string[] registerFiles = new string[]
            {
                "LINE.SMA.Repositories.dll",
            };
            //获取DLL文件
            List<string> assemblyFiles = Directory.GetFiles(assemblyDirectory, "*.dll").Select(path => Path.GetFileName(path)).ToList();
            assemblyFiles = assemblyFiles.Where(f => registerFiles.Contains(f)).ToList();
            return assemblyFiles;
        }

        public static List<Assembly> LoadAssembly()
        {
            List<string> assemblyFiles = GetAssemblyFiles();
            return AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assemblyFiles.Contains(assembly.ManifestModule.ScopeName)).ToList();
        }

        private static void RegisterType<T>(List<Type> types) where T : LifetimeManager, new()
        {
            types.AsParallel().ForAll(classType =>
            {
                List<Type> baseTypes = GetBaseTypes(classType);
                foreach (Type baseType in baseTypes)
                {
                    MyContainer.RegisterType(baseType, classType, new T());
                    MyContainer.RegisterType(baseType, classType, classType.FullName, new T());
                }
            });
        }

    }
}
