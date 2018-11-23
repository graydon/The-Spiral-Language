﻿let ar = [|1.174928; 0.0599458; 0.05994624; 1.16968; 1.175145; 1.169897; -0.06048824; -1.301142; -0.06026106; 1.289897; -1.300925; -0.06551887; -1.295895; 0.0546979; -0.06027097; -0.06026151; -1.295894; -1.300925; 0.05449011; -0.06573613; 0.05470782; -1.17546; -0.06551887; -1.180925; -0.06572621; -0.06048779; 1.175145; -1.180925; -1.300925; 0.05449056; -1.295894; 0.05448064; -1.180708; 1.175145; -1.180708; 1.16968; -0.06572666; -0.06026151; 1.295145; 1.174928; -0.06047878; 0.05470737; -1.17546; 1.295362; -0.0655094; 0.05973846; 0.05972854; 0.0599458; 0.0546979; 1.174928; 1.07498; -1.170678; 1.06725; 1.074939; 1.074982; 1.07494; -1.171463; 1.057501; 1.06638; 1.075814; -1.178107; -1.171497; -1.178073; -1.170713; -1.171462; -1.171461; 1.057543; -1.178107; -1.170714; -1.171498; 1.067208; 1.058409; -1.171497; 1.058365; 1.066337; 1.066379; 1.074982; 1.058365; -1.178107; 1.067207; 1.057543; -1.170714; 1.058367; 1.074982; 1.058367; 1.074939; -1.171498; -1.171461; 1.075855; 1.07498; -1.171463; -1.170713; 1.058409; -1.163886; -1.171497; 1.067249; -1.170679; -1.170678; -1.170713; 1.07498|]
let x = 
    Array.map (fun x -> x*x) ar
    |> Array.sum
    |> fun x -> x / float ar.Length
    |> sqrt

let a = [|-2.0; 2.0; 1.98; -1.98; 2.0; 2.0; -1.98; -1.98; 1.98; -2.0|]
let b = [|0; 0; -1; 1; 0; 0; 1; 1; -1; 0|] |> Array.map float
Array.fold2 (fun s a b -> s + a * b) 0.0 a b

let sigmoid x = 1.0 / (1.0 + exp -x)
sigmoid 3.0
let log_sigmoid = log << sigmoid
let log_sigmoid' x = log 1.0 - log (1.0 + exp -x)
log_sigmoid -100.0
log_sigmoid' -100.0

log10 1.0

let sqrt_sigmoid = sqrt << sigmoid
sqrt_sigmoid -12.0

exp 5.0

exp 0.4

let wrapped sup l x = l * exp (-l * x) / (1.0 - exp (-sup*l))
//let f = wrapped 1.0 1.0

0.5 ** -4.0

let f upper lower x = exp (x * log upper + (1.0 - x) * log lower)
f 0.1 0.001 -1.0

log 0.1
