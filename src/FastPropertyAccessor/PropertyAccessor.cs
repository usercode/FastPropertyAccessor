using System.Collections.Concurrent;
using System.Reflection;

namespace FastPropertyAccessor;

/// <summary>
/// PropertyAccessor
/// </summary>
public abstract class PropertyAccessor
{
    private static readonly ConcurrentDictionary<PropertyInfo, PropertyAccessor> _cache = new();

    /// <summary>
    /// Get
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <returns></returns>
    public static PropertyAccessor Get(PropertyInfo propertyInfo)
    {
        return _cache.GetOrAdd(propertyInfo, static key =>
        {
            PropertyAccessor accessor = (PropertyAccessor?)Activator.CreateInstance(typeof(PropertyAccessor<,>)
                            .MakeGenericType(key.ReflectedType!, key.PropertyType),
                            key) ?? throw new Exception("Couldn't create property accessor!");

            return accessor;
        });
    }

    public PropertyAccessor(PropertyInfo propertyInfo)
    {
        PropertyInfo = propertyInfo;
        Name = propertyInfo.Name;
    }

    /// <summary>
    /// PropertyInfo
    /// </summary>
    public PropertyInfo PropertyInfo { get; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// CanRead
    /// </summary>
    public bool CanRead { get; protected set; }

    /// <summary>
    /// CanWrite
    /// </summary>
    public bool CanWrite { get; protected set; }

    /// <summary>
    /// GetValue
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract object? GetValue(object target);

    /// <summary>
    /// SetValue
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetValue(object target, object? value);

    /// <summary>
    /// GetByteValue
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract byte GetByteValue(object target);

    /// <summary>
    /// SetByteValue
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetByteValue(object target, byte value);

    /// <summary>
    /// GetBoolValue
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract bool GetBoolValue(object target);

    /// <summary>
    /// SetBoolValue
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetBoolValue(object target, bool value);

    /// <summary>
    /// GetInt16Value
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract long GetInt16Value(object target);

    /// <summary>
    /// SetInt16Value
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetInt16Value(object target, short value);

    /// <summary>
    /// GetInt32Value
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract int GetInt32Value(object target);

    /// <summary>
    /// SetInt32Value
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetInt32Value(object target, int value);

    /// <summary>
    /// GetInt64Value
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract long GetInt64Value(object target);

    /// <summary>
    /// SetInt64Value
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetInt64Value(object target, long value);

    /// <summary>
    /// GetFloatValue
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract float GetFloatValue(object target);

    /// <summary>
    /// SetFloatValue
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetFloatValue(object target, float value);

    /// <summary>
    /// GetDoubleValue
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract double GetDoubleValue(object target);

    /// <summary>
    /// SetDoubleValue
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetDoubleValue(object target, double value);

    /// <summary>
    /// GetDateTimeValue
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public abstract DateTime GetDateTimeValue(object target);

    /// <summary>
    /// SetDateTimeValue
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public abstract void SetDateTimeValue(object target, DateTime value);
}