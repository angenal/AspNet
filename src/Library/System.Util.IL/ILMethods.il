#include "coreassembly.h"

.assembly System.Util.IL
{
  .ver 1:0:0:0
}

.module System.Util.IL.dll

.class public abstract auto ansi sealed beforefieldinit System.Util.IL.Unsafe
{
  .method public hidebysig static void Calli (void* ptr) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    calli unmanaged cdecl void()
    ret
  }
  
  .method public hidebysig static void Calli (void* ptr, native int para1) cil managed aggressiveinlining
  {
    .maxstack 2
    ldarg.1
    ldarg.0
    calli unmanaged cdecl void(void*)
    ret
  }
  
  .method public hidebysig static void Calli (void* ptr, native int para1, native int par2) cil managed aggressiveinlining
  {
    .maxstack 3
    ldarg.1
    ldarg.2
    ldarg.0
    calli unmanaged cdecl void(void*, void*)
    ret
  }
  
  .method public hidebysig static void Calli (void* ptr, native int para1, native int par2, native int par3) cil managed aggressiveinlining
  {
    .maxstack 4
    ldarg.1
    ldarg.2
    ldarg.3
    ldarg.0
    calli unmanaged cdecl void(void*, void*, void*)
    ret
  }
  
  .method public hidebysig static void Calli (void* ptr, native int para1, native int par2, native int par3, native int par4) cil managed aggressiveinlining
  {
    .maxstack 5
    ldarg.1
    ldarg.2
    ldarg.3
    ldarg.s 4
    ldarg.0
    calli unmanaged cdecl void(void*, void*, void*, void*)
    ret
  }
    .method public hidebysig static void Calli (void* ptr, native int para1, native int par2, native int par3, native int par4, native int par5) cil managed aggressiveinlining
  {
    .maxstack 6
    ldarg.1
    ldarg.2
    ldarg.3
    ldarg.s 4
    ldarg.s 5
    ldarg.0
    calli unmanaged cdecl void(void*, void*, void*, void*, void*)
    ret
  }

  .method public hidebysig static !!T DirectAs<T> (object o) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    ret
  }
  
  .method public hidebysig static !!TTo& DirectAs<TFrom,TTo> (!!TFrom& o) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    ret
  }
  
  .method public hidebysig static !!T& DirectAsRef<T> (!!T o) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    ret
  }
  
  .method public hidebysig static void* AsPointer<T> (!!T& o) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    conv.u
    ret
  }
  
  .method public hidebysig static !!T& AsRef<T> (void* p) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    ret
  }
  
  .method public hidebysig static !!T UnRef<T> (void* ptr) cil managed aggressiveinlining
  {
    .maxstack 1
    ldarg.0
    ldobj !!T
    ret
  }
  
  .method public hidebysig static int32 SizeOf<T>() cil managed aggressiveinlining
  {
    .maxstack 1
    sizeof !!T
    ret
  }
  
  .method public hidebysig static void InitBlock(void* startAddress, uint8 val, uint32 count) cil managed aggressiveinlining
  {
    .maxstack 3
    ldarg.0
    ldarg.1
    ldarg.2
    initblk
    ret
  }
  
  .method public hidebysig static void CopyBlock(void* destAddress, void* srcAddress, uint32 count) cil managed aggressiveinlining
  {
    .maxstack 3
    ldarg.0
    ldarg.1
    ldarg.2
    cpblk
    ret
  } 
}