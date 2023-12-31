﻿using Amazon.JSII.JsonModel.Spec;
using Newtonsoft.Json;
using System;

namespace Amazon.JSII.Runtime.Deputy
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsiiPropertyAttribute : Attribute, IOptionalValue
    {
        public JsiiPropertyAttribute(
            string name,
            string typeJson,
            bool isOptional = false,
            // Unused, retained for backwards-compatibility
            bool isOverride = false)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = JsonConvert.DeserializeObject<TypeReference>(typeJson ??
                                                                throw new ArgumentNullException(nameof(typeJson)))
                   ?? throw new ArgumentException("Invalid JSON descriptor", nameof(typeJson));
            IsOptional = isOptional;
        }

        public string Name { get; }

        public TypeReference Type { get; }

        public bool IsOptional { get; }
    }
}
