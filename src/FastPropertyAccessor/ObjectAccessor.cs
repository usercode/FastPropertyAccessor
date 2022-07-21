﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastPropertyAccessor;

/// <summary>
/// ObjectAccessor
/// </summary>
public class ObjectAccessor
{
    private static ConcurrentDictionary<Type, ObjectAccessor> _cache = new();

    /// <summary>
    /// Get
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ObjectAccessor Get(Type type)
    {
        return _cache.GetOrAdd(type, static key =>
        {
            ObjectAccessor objectAccessor = new ObjectAccessor();

            foreach (PropertyInfo pi in key.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                objectAccessor._properties.Add(pi.Name, PropertyAccessor.Get(pi));
            }

            return objectAccessor;
        });
    }
    
    private Dictionary<string, PropertyAccessor> _properties = new();

    /// <summary>
    /// GetProperty
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public PropertyAccessor GetProperty(string name)
    {
        if (_properties.TryGetValue(name, out PropertyAccessor? propertyAccessor) == false)
        {
            throw new Exception($"Property '{name}' wasn't found.");
        }

        return propertyAccessor;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public object? this[object obj, string property]
    {
        get
        {
            PropertyAccessor accessor = GetProperty(property);
            return accessor.GetValue(obj);
        }
        set
        {
            PropertyAccessor accessor = GetProperty(property);
            accessor.SetValue(obj, value);
        }
    }
}
