using System.Reflection;

namespace FastPropertyAccessor;

internal class PropertyAccessor<TTarget, TProperty> : PropertyAccessor
{
    public PropertyAccessor(PropertyInfo propertyInfo)
        : base(propertyInfo)
    {
        if (propertyInfo.GetGetMethod() is MethodInfo getMethod)
        {
            CanRead = true;

            _getter = getMethod.CreateDelegate<Func<TTarget, TProperty>>();

            if (typeof(TProperty) == typeof(byte))
            {
                _getterByte = getMethod.CreateDelegate<Func<TTarget, byte>>();
            }
            else if (typeof(TProperty) == typeof(bool))
            {
                _getterBool = getMethod.CreateDelegate<Func<TTarget, bool>>();
            }
            else if (typeof(TProperty) == typeof(short))
            {
                _getterInt16 = getMethod.CreateDelegate<Func<TTarget, short>>();
            }
            else if (typeof(TProperty) == typeof(int))
            {
                _getterInt32 = getMethod.CreateDelegate<Func<TTarget, int>>();
            }
            else if (typeof(TProperty) == typeof(long))
            {
                _getterInt64 = getMethod.CreateDelegate<Func<TTarget, long>>();
            }
            else if (typeof(TProperty) == typeof(DateTime))
            {
                _getterDateTime = getMethod.CreateDelegate<Func<TTarget, DateTime>>();
            }
        }

        if (propertyInfo.GetSetMethod() is MethodInfo setMethod)
        {
            CanWrite = true;

            _setter = setMethod.CreateDelegate<Action<TTarget, TProperty>>();
            
            if (typeof(TProperty) == typeof(byte))
            {
                _setterByte = setMethod.CreateDelegate<Action<TTarget, byte>>();

            }
            else if (typeof(TProperty) == typeof(bool))
            {
                _setterBool = setMethod.CreateDelegate<Action<TTarget, bool>>();
            }
            else if (typeof(TProperty) == typeof(short))
            {
                _setterInt16 = setMethod.CreateDelegate<Action<TTarget, short>>();
            }
            else if (typeof(TProperty) == typeof(int))
            {
                _setterInt32 = setMethod.CreateDelegate<Action<TTarget, int>>();
            }
            else if (typeof(TProperty) == typeof(long))
            {
                _setterInt64 = setMethod.CreateDelegate<Action<TTarget, long>>();
            }
            else if (typeof(TProperty) == typeof(DateTime))
            {
                _setterDateTime = setMethod.CreateDelegate<Action<TTarget, DateTime>>();
            }
        }
    }

    private readonly Func<TTarget, TProperty?>? _getter;
    private readonly Action<TTarget, TProperty>? _setter;

    public override object? GetValue(object target)
    {
        ArgumentNullException.ThrowIfNull(_getter);

        return _getter((TTarget)target);
    }

    public override void SetValue(object target, object? value)
    {
        ArgumentNullException.ThrowIfNull(_setter);

        _setter((TTarget)target, (TProperty)value!);
    }

    #region byte
    private readonly Func<TTarget, byte>? _getterByte;
    private readonly Action<TTarget, byte>? _setterByte;

    public override byte GetByteValue(object target)
    {
        ArgumentNullException.ThrowIfNull(_getterByte);

        return _getterByte((TTarget)target);
    }

    public override void SetByteValue(object target, byte value)
    {
        ArgumentNullException.ThrowIfNull(_setterByte);

        _setterByte((TTarget)target, value);
    }
    #endregion

    #region bool
    private readonly Func<TTarget, bool>? _getterBool;
    private readonly Action<TTarget, bool>? _setterBool;

    public override bool GetBoolValue(object target)
    {
        ArgumentNullException.ThrowIfNull(_getterBool);

        return _getterBool((TTarget)target);
    }

    public override void SetBoolValue(object target, bool value)
    {
        ArgumentNullException.ThrowIfNull(_setterBool);

        _setterBool((TTarget)target, value);
    }
    #endregion

    #region Int16
    private readonly Func<TTarget, short>? _getterInt16;
    private readonly Action<TTarget, short>? _setterInt16;

    public override long GetInt16Value(object target)
    {
        ArgumentNullException.ThrowIfNull(_getterInt16);

        return _getterInt16((TTarget)target);
    }

    public override void SetInt16Value(object target, short value)
    {
        ArgumentNullException.ThrowIfNull(_setterInt16);

        _setterInt16((TTarget)target, value);
    }
    #endregion

    #region Int32
    private readonly Func<TTarget, int>? _getterInt32;
    private readonly Action<TTarget, int>? _setterInt32;

    public override int GetInt32Value(object target)
    {
        ArgumentNullException.ThrowIfNull(_getterInt32);

        return _getterInt32((TTarget)target);
    }

    public override void SetInt32Value(object target, int value)
    {
        ArgumentNullException.ThrowIfNull(_setterInt32);

        _setterInt32((TTarget)target, value);
    }
    #endregion

    #region Int64
    private readonly Func<TTarget, long>? _getterInt64;
    private readonly Action<TTarget, long>? _setterInt64;

    public override long GetInt64Value(object target)
    {
        ArgumentNullException.ThrowIfNull(_getterInt64);

        return _getterInt64((TTarget)target);
    }

    public override void SetInt64Value(object target, long value)
    {
        ArgumentNullException.ThrowIfNull(_setterInt64);

        _setterInt64((TTarget)target, value);
    }
    #endregion

    #region DateTime
    private readonly Func<TTarget, DateTime>? _getterDateTime;
    private readonly Action<TTarget, DateTime>? _setterDateTime;

    public override DateTime GetDateTimeValue(object target)
    {
        ArgumentNullException.ThrowIfNull(_getterDateTime);

        return _getterDateTime((TTarget)target);
    }

    public override void SetDateTimeValue(object target, DateTime value)
    {
        ArgumentNullException.ThrowIfNull(_setterDateTime);

        _setterDateTime((TTarget)target, value);
    }
    #endregion
}
