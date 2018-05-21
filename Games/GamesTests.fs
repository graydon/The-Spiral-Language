﻿module Games.Tests

open Spiral.Lib
open Spiral.Tests
open System.IO
open Spiral.Types
open Module
open Learning.Module

let cfg: Spiral.Types.CompilerSettings = {
    path_cuda90 = "C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0"
    path_cub = "C:/cub-1.7.4"
    path_vs2017 = "C:/Program Files (x86)/Microsoft Visual Studio/2017/Community"
    cuda_includes = ["cub/cub.cuh"]
    trace_length = 40
    cuda_assert_enabled = false
    }

let poker1 =
    "poker1",[poker],"Does the poker game work?",
    """
inl log = Console.printfn
inl num_players = 2
inl max_stack_size = 32
open Poker {log max_stack_size num_players}

inl a = player_random {name="One"}
inl b = player_random {name="Two"}

game 10 (a,b)
    """

let poker2 =
    "poker2",[loops;poker;timer],"What is the winrate of the tabular (MC) RL based player against the random one?",
    """
inl num_players = 2
inl max_stack_size = 32
open Poker {max_stack_size num_players}

inl a = player_mc {init=10f64; learning_rate=0.02f64; name="One"}
inl b = player_random {name="Two"}

met f (!dyn near_to) (!dyn near_to_inner) = 
    Loops.for {from=0; near_to body=inl {i} ->
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            inl a = a.data_add {win=ref 0}
            inl b = b.data_add {win=ref 0}
            Loops.for {from=0; near_to=near_to_inner; body=inl {state=s i} -> game 10 (a, b)}
            inl a = a.data.win ()
            inl b = b.data.win ()
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
        }

f 10 100000
    """

let poker3 =
    "poker3",[cuda_modules;loops;poker;timer],"What is the winrate of the vanilla PG player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl num_players = 2
inl max_stack_size = 32
open Poker {max_stack_size num_players}
inl a = player_pg {learning_rate=3.0f32; name="One"} s
inl b = player_random {name="Two"}

met f (!dyn near_to) (!dyn near_to_inner) = 
    Loops.for {from=0; near_to body=inl {i} ->
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a = a.data_add {win=ref 0; state=ref (box_net_state a.net {} s); cd=s}
            inl b = b.data_add {win=ref 0}
            Loops.for {from=0; near_to=near_to_inner; body=inl {state=s i} -> game 10 (a, b)}
            inl a = a.data.win ()
            inl b = b.data.win ()
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
        }

f 10 1000
    """

let poker4 =
    "poker4",[cuda_modules;loops;poker;timer],"What is the winrate of the deep MC player against the random one?",
    """
inb s = CudaModules (1024*1024*1024)
inl num_players = 2
inl stack_size = 10
inl max_stack_size = num_players * stack_size
open Poker {max_stack_size num_players}
inl a = player_dmc {learning_rate=0.01f32; name="One"} s
inl b = player_random {name="Two"}

met f (!dyn near_to) (!dyn near_to_inner) = 
    Loops.for {from=0; near_to body=inl {i} ->
        Timer.time_it (string_format "iteration {0}" i)
        <| inl _ ->
            s.refresh
            inb s = s.RegionMem.create'
            inl a = a.data_add {win=ref 0; state=ref (box_net_state a.net {} s); cd=s}
            inl b = b.data_add {win=ref 0}
            Loops.for {from=0; near_to=near_to_inner; body=inl {state=s i} -> game stack_size (a, b)}
            inl a = a.data.win ()
            inl b = b.data.win ()
            Console.printfn "Winrate is {0} and {1} out of {2}." (a,b,a+b)
        }

f 10 1000
    """

output_test_to_temp cfg (Path.Combine(__SOURCE_DIRECTORY__, @"..\Temporary\output.fs")) poker4
|> printfn "%s"
|> ignore

