using System;
using System.Collections.Generic;
using System.Windows.Controls;
using DependencyResolution;
using Itk.Explorer.Core;

namespace Itk.Explorer.Ui.Components
{
    public sealed class DependencyInjector : ContentControl
    {
        public DependencyInjector()
        {
            this.ProvideInstance(new BasicInjector().AddInstance(EventBus.Create()));
        }

        private sealed class BasicInjector : IInjector
        {
            private readonly IDictionary<Type, object> _instances = new Dictionary<Type, object>();

            public IInjector AddInstance<TInstance>(TInstance dependency)
            {
                if (dependency != null)
                    _instances.Add(typeof(TInstance), dependency);
                return this;
            }

            public object ResolveInstance(Type key)
            {
                return _instances.ContainsKey(key) ? _instances[key] : null;
            }
        }
    }
}