module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: ManagedCuda.BasicTypes.CUdeviceptr
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env2 =
    struct
    val mem_0: Env3
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env3 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env3 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env2) = var_1.Peek()
        let (var_7: Env3) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env3), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env3) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_5((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_6((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: (Union0 ref)), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64)): unit =
    let (var_14: int64) = (var_11 - var_10)
    let (var_15: int64) = (var_13 - var_12)
    let (var_16: int64) = (var_14 * var_15)
    let (var_17: bool) = (var_10 < var_11)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_19: bool) = (var_12 < var_13)
    let (var_20: bool) = (var_19 = false)
    if var_20 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_21: bool) = (0L = var_7)
    let (var_22: bool) = (var_21 = false)
    if var_22 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_23: bool) = (var_6 = 0L)
    let (var_24: bool) = (var_23 = false)
    if var_24 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_5: (Union0 ref)))
    let (var_26: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_16))
    var_0.CopyToHost(var_26, var_25)
    var_0.Synchronize()
    let (var_27: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_28: string) = ""
    let (var_29: int64) = 0L
    method_7((var_27: System.Text.StringBuilder), (var_29: int64))
    let (var_30: System.Text.StringBuilder) = var_27.AppendLine("[|")
    method_8((var_27: System.Text.StringBuilder), (var_28: string), (var_26: (float32 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_31: int64) = 0L
    method_7((var_27: System.Text.StringBuilder), (var_31: int64))
    let (var_32: System.Text.StringBuilder) = var_27.AppendLine("|]")
    let (var_33: string) = var_27.ToString()
    let (var_34: string) = System.String.Format("{0}",var_33)
    System.Console.WriteLine(var_34)
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env3), (var_6: int64)): Env3 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: uint64) = (var_8 - var_1)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: uint64) = uint64 var_3
    let (var_13: uint64) = (var_12 + var_11)
    let (var_14: bool) = (var_13 <= var_2)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_16: uint64) = (var_8 + var_9)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_18))))
    var_4.Push((Env2((Env3(var_19)), var_3)))
    (Env3(var_19))
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env3 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_8))))
    var_3.Push((Env2((Env3(var_9)), var_2)))
    (Env3(var_9))
and method_7((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_7((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_8((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
    let (var_11: bool) = (var_7 < var_8)
    if var_11 then
        let (var_12: bool) = (var_7 >= var_7)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_14: int64) = (var_3 + var_4)
        let (var_15: int64) = 0L
        method_9((var_0: System.Text.StringBuilder), (var_15: int64))
        let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_17: string) = method_10((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_14: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_19: int64) = (var_7 + 1L)
        method_12((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_19: int64))
    else
        ()
and method_9((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_9((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_10((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
    let (var_7: bool) = (var_4 < var_5)
    if var_7 then
        let (var_8: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_9: bool) = (var_4 >= var_4)
        let (var_10: bool) = (var_9 = false)
        if var_10 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_11: float32) = var_1.[int32 var_2]
        let (var_12: string) = System.String.Format("{0}",var_11)
        let (var_13: System.Text.StringBuilder) = var_0.Append(var_12)
        let (var_14: string) = "; "
        let (var_15: int64) = (var_4 + 1L)
        method_11((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_14: string), (var_15: int64))
    else
        var_6
and method_12((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
    let (var_12: bool) = (var_11 < var_8)
    if var_12 then
        let (var_13: bool) = (var_11 >= var_7)
        let (var_14: bool) = (var_13 = false)
        if var_14 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_15: int64) = (var_11 - var_7)
        let (var_16: int64) = (var_15 * var_5)
        let (var_17: int64) = (var_3 + var_16)
        let (var_18: int64) = (var_17 + var_4)
        let (var_19: int64) = 0L
        method_9((var_0: System.Text.StringBuilder), (var_19: int64))
        let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_21: string) = method_10((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_23: int64) = (var_11 + 1L)
        method_12((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_23: int64))
    else
        ()
and method_11((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): string =
    let (var_8: bool) = (var_7 < var_5)
    if var_8 then
        let (var_9: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_10: bool) = (var_7 >= var_4)
        let (var_11: bool) = (var_10 = false)
        if var_11 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_12: int64) = (var_7 - var_4)
        let (var_13: int64) = (var_12 * var_3)
        let (var_14: int64) = (var_2 + var_13)
        let (var_15: float32) = var_1.[int32 var_14]
        let (var_16: string) = System.String.Format("{0}",var_15)
        let (var_17: System.Text.StringBuilder) = var_0.Append(var_16)
        let (var_18: string) = "; "
        let (var_19: int64) = (var_7 + 1L)
        method_11((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_18: string), (var_19: int64))
    else
        var_6
let (var_0: string) = cuda_kernels
let (var_1: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_1.Synchronize()
let (var_2: string) = System.Environment.get_CurrentDirectory()
let (var_3: string) = System.IO.Path.Combine(var_2, "nvcc_router.bat")
let (var_4: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_4.set_RedirectStandardOutput(true)
var_4.set_RedirectStandardError(true)
var_4.set_UseShellExecute(false)
var_4.set_FileName(var_3)
let (var_5: System.Diagnostics.Process) = System.Diagnostics.Process()
var_5.set_StartInfo(var_4)
let (var_7: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_5.OutputDataReceived.Add(var_7)
var_5.ErrorDataReceived.Add(var_7)
let (var_8: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Auxiliary\\Build\\vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\bin\\Hostx64\\x64")
let (var_10: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\include")
let (var_12: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "bin\\nvcc.exe")
let (var_13: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_14: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_15: bool) = System.IO.File.Exists(var_14)
if var_15 then
    System.IO.File.Delete(var_14)
else
    ()
System.IO.File.WriteAllText(var_14, var_0)
let (var_16: bool) = System.IO.File.Exists(var_3)
if var_16 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_17: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_18: System.IO.StreamWriter) = System.IO.StreamWriter(var_17)
var_18.WriteLine("SETLOCAL")
let (var_19: string) = String.concat "" [|"CALL "; "\""; var_8; "\""|]
var_18.WriteLine(var_19)
let (var_20: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_9; "\""|]
var_18.WriteLine(var_20)
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:\\cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
var_18.WriteLine(var_21)
var_18.Dispose()
var_17.Dispose()
let (var_22: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_23: bool) = var_5.Start()
let (var_24: bool) = (var_23 = false)
if var_24 then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_25: int32) = var_5.get_ExitCode()
let (var_26: bool) = (var_25 = 0)
let (var_27: bool) = (var_26 = false)
if var_27 then
    let (var_28: string) = System.String.Format("{0}",var_25)
    let (var_29: string) = String.concat ", " [|"NVCC failed compilation."; var_28|]
    let (var_30: string) = System.String.Format("[{0}]",var_29)
    (failwith var_30)
else
    ()
let (var_31: System.TimeSpan) = var_22.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_31
let (var_32: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_33: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_2|]
let (var_34: string) = System.String.Format("{0}",var_33)
System.Console.WriteLine(var_34)
let (var_35: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_36: ManagedCuda.BasicTypes.SizeT) = var_35.get_TotalGlobalMemory()
let (var_37: int64) = int64 var_36
let (var_38: float) = float var_37
let (var_39: float) = (0.700000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
let (var_46: ManagedCuda.BasicTypes.SizeT) = var_45.Pointer
let (var_47: uint64) = uint64 var_46
let (var_48: uint64) = uint64 var_40
let (var_49: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_50: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_51: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_50)
let (var_52: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_51.SetStream(var_52)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaBlas.CudaBlasHandle) = var_55.get_CublasHandle()
let (var_57: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_55.set_Stream(var_57)
let (var_58: int64) = 64L
let (var_59: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_58: int64))
let (var_60: (Union0 ref)) = var_59.mem_0
let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_62: ManagedCuda.BasicTypes.SizeT) = var_61.Pointer
let (var_63: uint64) = uint64 var_62
let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_63)
let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_64)
let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16L)
var_51.GenerateNormal32(var_65, var_66, 0.000000f, 1.000000f)
let (var_67: int64) = 64L
let (var_68: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_67: int64))
let (var_69: (Union0 ref)) = var_68.mem_0
let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_71: ManagedCuda.BasicTypes.SizeT) = var_70.Pointer
let (var_72: uint64) = uint64 var_71
let (var_73: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_72)
let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_73)
let (var_75: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16L)
var_51.GenerateNormal32(var_74, var_75, 0.000000f, 1.000000f)
let (var_76: int64) = 16L
let (var_77: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_76: int64))
let (var_78: (Union0 ref)) = var_77.mem_0
let (var_79: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_80: ManagedCuda.BasicTypes.SizeT) = var_79.Pointer
let (var_81: uint64) = uint64 var_80
let (var_82: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_81)
let (var_83: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_82)
let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_85: ManagedCuda.BasicTypes.SizeT) = var_84.Pointer
let (var_86: uint64) = uint64 var_85
let (var_87: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_86)
let (var_88: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_87)
let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_78: (Union0 ref)))
let (var_90: ManagedCuda.BasicTypes.SizeT) = var_89.Pointer
let (var_91: uint64) = uint64 var_90
let (var_92: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_91)
let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_92)
let (var_94: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_95: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_96: (float32 ref)) = (ref 1.000000f)
let (var_97: (float32 ref)) = (ref 0.000000f)
let (var_98: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_56, var_94, var_95, 2, 2, 8, var_96, var_83, 2, var_88, 8, var_97, var_93, 2)
if var_98 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_98)
let (var_99: int64) = 16L
let (var_100: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_99: int64))
let (var_101: (Union0 ref)) = var_100.mem_0
let (var_102: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_101: (Union0 ref)))
let (var_103: ManagedCuda.BasicTypes.SizeT) = var_102.Pointer
let (var_104: uint64) = uint64 var_103
let (var_105: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_104)
let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_105)
let (var_107: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_108: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16L)
var_1.ClearMemoryAsync(var_106, 0uy, var_108, var_107)
let (var_109: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_101: (Union0 ref)))
let (var_110: ManagedCuda.BasicTypes.SizeT) = var_109.Pointer
let (var_111: uint64) = uint64 var_110
let (var_112: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_111)
let (var_113: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_112)
let (var_114: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_115: ManagedCuda.BasicTypes.SizeT) = var_114.Pointer
let (var_116: uint64) = uint64 var_115
let (var_117: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_116)
let (var_118: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_117)
let (var_119: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_120: ManagedCuda.BasicTypes.SizeT) = var_119.Pointer
let (var_121: uint64) = uint64 var_120
let (var_122: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_121)
let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_122)
let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_101: (Union0 ref)))
let (var_125: ManagedCuda.BasicTypes.SizeT) = var_124.Pointer
let (var_126: uint64) = uint64 var_125
let (var_127: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_126)
let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_127)
let (var_129: int64) = 0L
let (var_130: int64) = 0L
let (var_131: int64) = 2L
let (var_132: int64) = 1L
let (var_133: int64) = 0L
let (var_134: int64) = 2L
let (var_135: int64) = 0L
let (var_136: int64) = 2L
method_6((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_78: (Union0 ref)), (var_129: int64), (var_130: int64), (var_131: int64), (var_132: int64), (var_133: int64), (var_134: int64), (var_135: int64), (var_136: int64))
var_101 := Union0Case1
var_78 := Union0Case1
var_69 := Union0Case1
var_60 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_137)
var_43 := Union0Case1
var_1.Dispose()

