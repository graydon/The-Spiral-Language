module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Env0 {
        long long int mem_0;
    };
    __device__ __forceinline__ Env0 make_Env0(long long int mem_0){
        Env0 tmp;
        tmp.mem_0 = mem_0;
        return tmp;
    }
    struct Tuple3 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(float mem_0, float mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer1)(float, float);
    struct Env2 {
        long long int mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Env2 make_Env2(long long int mem_0, float mem_1){
        Env2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    __global__ void method_5(float * var_0, float * var_1);
    __global__ void method_8(float * var_0, float * var_1);
    __global__ void method_10(float * var_0, float * var_1, float * var_2);
    __device__ char method_6(Env0 * var_0);
    __device__ float method_7(float var_0, float var_1);
    __device__ char method_9(Env2 * var_0);
    
    __global__ void method_5(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        Env0 var_8[1];
        var_8[0] = (make_Env0(var_5));
        while (method_6(var_8)) {
            Env0 var_10 = var_8[0];
            long long int var_11 = var_10.mem_0;
            long long int var_12 = (var_11 + 1);
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 1);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = (var_11 * 192);
            long long int var_18 = (var_17 + var_2);
            char var_19 = (var_18 < 192);
            float var_23;
            if (var_19) {
                char var_20 = (var_18 >= 0);
                char var_21 = (var_20 == 0);
                if (var_21) {
                    // "Argument out of bounds."
                } else {
                }
                var_23 = var_0[var_18];
            } else {
                var_23 = __int_as_float(0x7f800000);
            }
            FunPointer1 var_26 = method_7;
            float var_27 = cub::BlockReduce<float,192>().Reduce(var_23, var_26);
            char var_28 = (var_2 == 0);
            if (var_28) {
                var_1[var_11] = var_27;
            } else {
            }
            var_8[0] = (make_Env0(var_12));
        }
        Env0 var_29 = var_8[0];
        long long int var_30 = var_29.mem_0;
    }
    __global__ void method_8(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_3 + var_6);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_6(var_9)) {
            Env0 var_11 = var_9[0];
            long long int var_12 = var_11.mem_0;
            long long int var_13 = (var_12 + 1);
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 1);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            char var_19;
            if (var_14) {
                var_19 = (var_12 < 1);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_21 = (var_2 + var_5);
            float var_22 = __int_as_float(0x7f800000);
            Env2 var_23[1];
            var_23[0] = (make_Env2(var_21, var_22));
            while (method_9(var_23)) {
                Env2 var_25 = var_23[0];
                long long int var_26 = var_25.mem_0;
                float var_27 = var_25.mem_1;
                long long int var_28 = (var_26 + 1);
                char var_29 = (var_26 >= 0);
                char var_31;
                if (var_29) {
                    var_31 = (var_26 < 1);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_12 + var_26);
                char var_35;
                if (var_29) {
                    var_35 = (var_26 < 1);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                float var_37 = var_0[var_33];
                float var_38[1];
                var_38[0] = var_37;
                float var_39[1];
                float var_40[1];
                float var_41 = var_40[0];
                FunPointer1 var_44 = method_7;
                cub::BlockScan<float,1>().ExclusiveScan(var_38, var_39, var_27, var_44, var_41);
                float var_45 = var_39[0];
                float var_46 = var_1[var_33];
                var_1[var_33] = var_45;
                char var_47 = (var_27 > var_41);
                float var_48;
                if (var_47) {
                    var_48 = var_41;
                } else {
                    var_48 = var_27;
                }
                var_23[0] = (make_Env2(var_28, var_48));
            }
            Env2 var_49 = var_23[0];
            long long int var_50 = var_49.mem_0;
            float var_51 = var_49.mem_1;
            var_9[0] = (make_Env0(var_13));
        }
        Env0 var_52 = var_9[0];
        long long int var_53 = var_52.mem_0;
    }
    __global__ void method_10(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_6));
        while (method_6(var_9)) {
            Env0 var_11 = var_9[0];
            long long int var_12 = var_11.mem_0;
            long long int var_13 = (var_12 + 1);
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 1);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_2[var_12];
            long long int var_19 = (var_12 * 192);
            long long int var_20 = (var_19 + var_3);
            char var_21 = (var_20 < 192);
            if (var_21) {
                char var_22 = (var_20 >= 0);
                char var_23 = (var_22 == 0);
                if (var_23) {
                    // "Argument out of bounds."
                } else {
                }
                float var_24 = var_0[var_20];
                float var_25[1];
                var_25[0] = var_24;
                float var_26[1];
                FunPointer1 var_29 = method_7;
                cub::BlockScan<float,192>().InclusiveScan(var_25, var_26, var_29);
                float var_30 = var_26[0];
                char var_31 = (var_18 > var_30);
                float var_32;
                if (var_31) {
                    var_32 = var_30;
                } else {
                    var_32 = var_18;
                }
                if (var_23) {
                    // "Argument out of bounds."
                } else {
                }
                float var_33 = var_1[var_20];
                var_1[var_20] = var_32;
            } else {
            }
            var_9[0] = (make_Env0(var_13));
        }
        Env0 var_34 = var_9[0];
        long long int var_35 = var_34.mem_0;
    }
    __device__ char method_6(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 1);
    }
    __device__ float method_7(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_1;
        } else {
            return var_0;
        }
    }
    __device__ char method_9(Env2 * var_0) {
        Env2 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 1);
    }
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
and EnvStack2 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: EnvStack2
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
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
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env3) = var_1.Peek()
        let (var_7: EnvStack2) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_11((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64)): unit =
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
    let (var_25: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_16))
    let (var_26: (Union0 ref)) = var_5.mem_0
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_26: (Union0 ref)))
    var_0.CopyToHost(var_25, var_27)
    let (var_28: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_29: string) = ""
    let (var_30: int64) = 0L
    method_12((var_28: System.Text.StringBuilder), (var_30: int64))
    let (var_31: System.Text.StringBuilder) = var_28.AppendLine("[|")
    method_13((var_28: System.Text.StringBuilder), (var_29: string), (var_25: (float32 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_32: int64) = 0L
    method_12((var_28: System.Text.StringBuilder), (var_32: int64))
    let (var_33: System.Text.StringBuilder) = var_28.AppendLine("|]")
    let (var_34: string) = var_28.ToString()
    let (var_35: string) = System.String.Format("{0}",var_34)
    System.Console.WriteLine(var_35)
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: int64) = (var_3 % 256L)
    let (var_11: int64) = (var_3 - var_10)
    let (var_12: int64) = (var_11 + 256L)
    let (var_13: uint64) = (var_8 + var_9)
    let (var_14: uint64) = (var_1 + var_2)
    let (var_15: uint64) = uint64 var_12
    let (var_16: uint64) = (var_14 - var_13)
    let (var_17: bool) = (var_15 <= var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_12)))
    var_22
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: int64) = (var_2 % 256L)
    let (var_5: int64) = (var_2 - var_4)
    let (var_6: int64) = (var_5 + 256L)
    let (var_7: uint64) = (var_0 + var_1)
    let (var_8: uint64) = uint64 var_6
    let (var_9: uint64) = (var_7 - var_0)
    let (var_10: bool) = (var_8 <= var_9)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_13))))
    let (var_15: EnvStack2) = EnvStack2((var_14: (Union0 ref)))
    var_3.Push((Env3(var_15, var_6)))
    var_15
and method_12((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_12((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_13((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
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
        method_14((var_0: System.Text.StringBuilder), (var_15: int64))
        let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_17: string) = method_15((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_14: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_19: int64) = (var_7 + 1L)
        method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_19: int64))
    else
        ()
and method_14((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_14((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_15((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
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
        method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_14: string), (var_15: int64))
    else
        var_6
and method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
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
        method_14((var_0: System.Text.StringBuilder), (var_19: int64))
        let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_21: string) = method_15((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_23: int64) = (var_11 + 1L)
        method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_23: int64))
    else
        ()
and method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): string =
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
        method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_18: string), (var_19: int64))
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
let (var_8: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_10: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
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
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:/cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
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
let (var_39: float) = (0.100000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: EnvStack2) = EnvStack2((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_52: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_53: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_52)
let (var_54: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_53.SetStream(var_54)
let (var_55: int64) = 768L
let (var_56: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_55: int64))
let (var_57: (Union0 ref)) = var_56.mem_0
let (var_58: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
let (var_59: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(192L)
var_53.GenerateNormal32(var_58, var_59, 0.000000f, 1.000000f)
let (var_60: int64) = 768L
let (var_61: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_60: int64))
let (var_62: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
let (var_63: (Union0 ref)) = var_61.mem_0
let (var_64: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_63: (Union0 ref)))
let (var_65: int64) = 4L
let (var_66: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_65: int64))
let (var_67: (Union0 ref)) = var_66.mem_0
let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
// Cuda join point
// method_5((var_62: ManagedCuda.BasicTypes.CUdeviceptr), (var_68: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_69: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_5", var_32, var_1)
let (var_70: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_69.set_GridDimensions(var_70)
let (var_71: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(192u, 1u, 1u)
var_69.set_BlockDimensions(var_71)
let (var_72: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_74: (System.Object [])) = [|var_62; var_68|]: (System.Object [])
var_69.RunAsync(var_72, var_74)
let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
let (var_76: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
// Cuda join point
// method_8((var_75: ManagedCuda.BasicTypes.CUdeviceptr), (var_76: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_77: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_8", var_32, var_1)
let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_77.set_GridDimensions(var_78)
let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_77.set_BlockDimensions(var_79)
let (var_80: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_82: (System.Object [])) = [|var_75; var_76|]: (System.Object [])
var_77.RunAsync(var_80, var_82)
let (var_83: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
// Cuda join point
// method_10((var_62: ManagedCuda.BasicTypes.CUdeviceptr), (var_64: ManagedCuda.BasicTypes.CUdeviceptr), (var_83: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_84: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_10", var_32, var_1)
let (var_85: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_84.set_GridDimensions(var_85)
let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(192u, 1u, 1u)
var_84.set_BlockDimensions(var_86)
let (var_87: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_89: (System.Object [])) = [|var_62; var_64; var_83|]: (System.Object [])
var_84.RunAsync(var_87, var_89)
var_67 := Union0Case1
let (var_90: int64) = 0L
let (var_91: int64) = 0L
let (var_92: int64) = 64L
let (var_93: int64) = 1L
let (var_94: int64) = 0L
let (var_95: int64) = 3L
let (var_96: int64) = 0L
let (var_97: int64) = 64L
method_11((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_56: EnvStack2), (var_90: int64), (var_91: int64), (var_92: int64), (var_93: int64), (var_94: int64), (var_95: int64), (var_96: int64), (var_97: int64))
let (var_98: int64) = 0L
let (var_99: int64) = 0L
let (var_100: int64) = 64L
let (var_101: int64) = 1L
let (var_102: int64) = 0L
let (var_103: int64) = 3L
let (var_104: int64) = 0L
let (var_105: int64) = 64L
method_11((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_61: EnvStack2), (var_98: int64), (var_99: int64), (var_100: int64), (var_101: int64), (var_102: int64), (var_103: int64), (var_104: int64), (var_105: int64))
var_63 := Union0Case1
var_57 := Union0Case1
var_53.Dispose()
var_51.Dispose()
let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_106)
var_46 := Union0Case1
var_1.Dispose()

