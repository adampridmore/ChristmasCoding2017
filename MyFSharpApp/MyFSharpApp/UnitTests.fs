module UnitTests

open MyModule
open NUnit.Framework
open FsUnit

[<Test>]
let ``hello world test ``() =
  helloWorld 123 |> should equal "Hello World 123"