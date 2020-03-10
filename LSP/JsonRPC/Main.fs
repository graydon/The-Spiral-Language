﻿module JsonRPC

open System

type Trace =
    | Off
    | Messages
    | Verbose

    static member fromString (x : string) = function
        | "off" -> Off
        | "messages" -> Messages
        | "verbose" -> Verbose
        | _ -> failwithf "Expected one of: 'off', 'messages' or 'verbose'. Got: %s" x


type TraceFormat =
    | Text
    | JSON

    static member fromString (x : string) = function
        | "text" -> Text
        | "json" -> JSON
        | _ -> failwithf "Expected one of: 'text' or 'json'. Got: %s" x

type ConnectionErrors =
    | Closed
    | Disposed
    | AlreadyListening

type ConnectionState =
    | New
    | Listening
    | Closed
    | Disposed


let mutable c = 0
let x = Handler<_>(fun sender k -> c <- c + 1; printfn "c is %i" c)
x.Invoke(null,())
