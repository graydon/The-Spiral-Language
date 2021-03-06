﻿/// Error measurements for the reversible weight updates for Hebbian learning.

type R<'a> = {passes: int32; error : 'a}

let inline error_weight_norm num_weights float passes = 
    let n = float 0.01
    let zero = float 0.0
    let one = float 1.0

    let norm x =
        let mean = Array.sum x / num_weights
        let x = Array.map (fun x -> x - mean) x
        let std = Array.fold (fun s x -> s + x * x) zero x / num_weights |> sqrt
        // Note: It would be beter to not normalize stds < 1 in a real implementation
        // and let the weights grow naturally until then.
        Array.map (fun x -> if std <> zero then x / std else zero) x, mean, std 

    let unnorm x (mean,std) =
        Array.map (fun x -> if std <> zero then x * std else zero) x
        |> Array.map (fun x -> x + mean)

    let H' (H,mean,std) (input, out) = 
        let r = Array.map2 (fun H input -> H + n * input * out) H input |> norm
        r, r

    let H (input, out, mean, std) H' = 
        let H' = unnorm H' (mean, std)
        let r = Array.map2 (fun H' input -> H' - n * input * out) H' input //|> norm
        H',r

    let rng = System.Random()
    let num_weights = int num_weights

    let r_init, _, _ as weights = Array.init num_weights (fun _ -> rng.NextDouble() |> float) |> norm
    let input_out = Array.init passes (fun _ -> Array.init num_weights (fun _ -> rng.NextDouble() |> float), rng.NextDouble() |> float)

    let Hs, (r,_,_) = Array.mapFold H' weights input_out
    let input_out = Array.map2 (fun (input, out) (_, mean, std) -> input, out, mean, std) input_out Hs
    let H's, r' = Array.mapFoldBack H input_out r

    {passes=passes; error=Array.map2 (fun a b -> abs (a - b)) r_init r' |> Array.max}

   
let passes = [|500;1000;2000;3000;4000;5000;6000;7000;8000;9000;10000|] |> Array.map ((*) 20)
let num_weights = 256
printfn "The Weight Norm max abs error of vector of %i weights of type float32 is:" num_weights
Array.iter (error_weight_norm (float32 num_weights) float32 >> printfn "%A") passes

printfn "The Weight Norm max abs error of vector of %i weights of type float64 is:" num_weights
Array.iter (error_weight_norm (float num_weights) float >> printfn "%A") passes

