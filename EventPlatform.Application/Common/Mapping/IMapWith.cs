﻿using System.Runtime.CompilerServices;
using AutoMapper;

namespace EventPlatform.Application.Common.Mapping
{
    public interface IMapWith<T>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType())
                 .ReverseMap()
                 .ForAllMembers(opts =>
                 {
                     opts.Condition((src, dest, srcMember, destMember) =>
                     {
                         if (srcMember == null) return false;

                         var memberType = srcMember.GetType();
                         if (memberType.IsValueType && !memberType.IsEnum)
                         {
                             var defaultValue = RuntimeHelpers.GetUninitializedObject(memberType);
                             return !srcMember.Equals(defaultValue);
                         }

                         return true;
                     });
                 });
        }
    }
}
