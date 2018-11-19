using System;
using System.ComponentModel;
using System.Resources;

namespace ISUCorp.ReservationsProject.Core.Utils
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly ResourceManager resource;

        private readonly string resourceKey;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            this.resource = new ResourceManager(resourceType);
            this.resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                var displayName = this.resource.GetString(this.resourceKey);
                return string.IsNullOrEmpty(displayName)
                           ? $"[[{this.resourceKey}]]"
                           : displayName;
            }
        }
    }
}