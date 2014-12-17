﻿/*
 * Copyright 2014-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 *
 * Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located in the "license" file accompanying this file.
 * See the License for the specific language governing permissions and limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Amazon.Util
{
    internal interface ITypeInfo
    {
        Type BaseType { get; }

        Assembly Assembly { get; }
        bool IsArray { get; }

        Array ArrayCreateInstance(int length);

        Type GetInterface(string name);
        Type[] GetInterfaces();

        IEnumerable<PropertyInfo> GetProperties();

        IEnumerable<FieldInfo> GetFields();
        FieldInfo GetField(string name);

        MethodInfo GetMethod(string name);
        MethodInfo GetMethod(string name, ITypeInfo[] paramTypes);

        MemberInfo[] GetMembers();


        ConstructorInfo GetConstructor(ITypeInfo[] paramTypes);

        PropertyInfo GetProperty(string name);

        bool IsAssignableFrom(ITypeInfo typeInfo);

        bool IsEnum {get;}

        bool IsClass { get; }

        bool IsInterface { get; }
        bool IsAbstract { get; }

        object EnumToObject(object value);

        ITypeInfo EnumGetUnderlyingType();

        object CreateInstance();

        ITypeInfo GetElementType();

        bool IsType(Type type);

        string FullName { get; }
        string Name { get; }

        bool IsGenericTypeDefinition { get; }
        bool IsGenericType { get; }
        bool ContainsGenericParameters { get; }
        Type GetGenericTypeDefinition();
        Type[] GetGenericArguments();

        object[] GetCustomAttributes(bool inherit);
        object[] GetCustomAttributes(ITypeInfo attributeType, bool inherit);

    }

    internal static partial class TypeFactory
    {
        public static readonly ITypeInfo[] EmptyTypes = new ITypeInfo[] { };
        public static ITypeInfo GetTypeInfo(Type type)
        {
            if (type == null)
                return null;

            return new TypeInfoWrapper(type);
        }

        abstract class AbstractTypeInfo : ITypeInfo
        {
            protected Type _type;

            internal AbstractTypeInfo(Type type)
            {
                this._type = type;
            }

            public Type BaseType
            {
                get { return this._type; }
            }

            public Type Type
            {
                get{return this._type;}
            }

            public override int GetHashCode()
            {
                return this._type.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var typeWrapper = obj as AbstractTypeInfo;
                if (typeWrapper == null)
                    return false;

                return this._type.Equals(typeWrapper._type);
            }

            public bool IsType(Type type)
            {
                return this._type == type;
            }

            public abstract Assembly Assembly { get; }
            public abstract Type GetInterface(string name);
            public abstract Type[] GetInterfaces();
            public abstract IEnumerable<PropertyInfo> GetProperties();
            public abstract IEnumerable<FieldInfo> GetFields();
            public abstract FieldInfo GetField(string name);
            public abstract MethodInfo GetMethod(string name);
            public abstract MethodInfo GetMethod(string name, ITypeInfo[] paramTypes);
            public abstract MemberInfo[] GetMembers();
            public abstract PropertyInfo GetProperty(string name);
            public abstract bool IsAssignableFrom(ITypeInfo typeInfo);
            public abstract bool IsClass { get; }
            public abstract bool IsInterface { get; }
            public abstract bool IsAbstract { get; }
            public abstract bool IsEnum { get; }
            public abstract ConstructorInfo GetConstructor(ITypeInfo[] paramTypes);

            public abstract object[] GetCustomAttributes(bool inherit);
            public abstract object[] GetCustomAttributes(ITypeInfo attributeType, bool inherit);

            public abstract bool ContainsGenericParameters { get; }
            public abstract bool IsGenericTypeDefinition { get; }
            public abstract bool IsGenericType {get;}
            public abstract Type GetGenericTypeDefinition();
            public abstract Type[] GetGenericArguments();

            public bool IsArray
            {
                get { return this._type.IsArray; }
            }


            public object EnumToObject(object value)
            {
                return Enum.ToObject(this._type, value);
            }

            public ITypeInfo EnumGetUnderlyingType()
            {
                return TypeFactory.GetTypeInfo(Enum.GetUnderlyingType(this._type));
            }

            public object CreateInstance()
            {
                return Activator.CreateInstance(this._type);
            }

            public Array ArrayCreateInstance(int length)
            {
                return Array.CreateInstance(this._type, length);
            }

            public ITypeInfo GetElementType()
            {
                return TypeFactory.GetTypeInfo(this._type.GetElementType());
            }

            public string FullName 
            {
                get
                {
                    return this._type.FullName;
                }
            }

            public string Name
            {
                get
                {
                    return this._type.Name;
                }
            }
       }
    }


}