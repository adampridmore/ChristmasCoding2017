module UnitTests

open MyModule
open NUnit.Framework

[<Test>]
let helloWorldTest() =
  Assert.AreEqual("Hello World 123", (helloWorld 123));