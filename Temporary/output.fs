module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Tuple0 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    val mem_4: int64
    val mem_5: int64
    val mem_6: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4, arg_mem_5, arg_mem_6) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4; mem_5 = arg_mem_5; mem_6 = arg_mem_6}
    end
let rec method_0((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 1024L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        var_0.[int32 var_1] <- var_1
        let (var_5: int64) = (var_1 + 1L)
        method_0((var_0: (int64 [])), (var_5: int64))
    else
        ()
let (var_0: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(1024L))
let (var_1: int64) = 0L
method_0((var_0: (int64 [])), (var_1: int64))
let (var_2: int64) = var_0.[int32 0L]
let (var_3: int64) = var_0.[int32 1L]
let (var_4: int64) = var_0.[int32 2L]
let (var_5: int64) = var_0.[int32 64L]
let (var_6: int64) = var_0.[int32 65L]
let (var_7: int64) = var_0.[int32 66L]
let (var_8: int64) = var_0.[int32 123L]
Tuple0(var_2, var_3, var_4, var_5, var_6, var_7, var_8)
