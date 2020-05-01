using System;
using UnhollowerBaseLib;

namespace UnhollowerRuntimeLib
{
    public static class Il2CppTypeOf
    {
        public static Il2CppSystem.Type TypeFromPointer(IntPtr classPointer, string typeName = "<unknown type>")
        {
            if (classPointer == IntPtr.Zero) throw new ArgumentException($"{typeName} does not have a corresponding IL2CPP class pointer");
            var il2CppType = IL2CPP.il2cpp_class_get_type(classPointer);
            if (il2CppType == IntPtr.Zero) throw new ArgumentException($"{typeName} does not have a corresponding IL2CPP type pointer");
            return Il2CppSystem.Type.internal_from_handle(il2CppType);
        }
    }
    
    public static class Il2CppTypeOf<T>
    {
        public static Il2CppSystem.Type Type
        {
            get
            {
                var classPointer = Il2CppClassPointerStore<T>.NativeClassPtr;
                return Il2CppTypeOf.TypeFromPointer(classPointer);
            }
        }
    }
}