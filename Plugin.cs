using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace VipBcCassieFeatures
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(valueFactory: () => new Plugin());
        public static Plugin Instance => LazyInstance.Value;
        private Plugin() { }

        public override string Author { get; } = "Evito";
        public override PluginPriority Priority { get; } = PluginPriority.Low;
        public override void OnEnabled() { }
        public override void OnDisabled() { }
    }
}