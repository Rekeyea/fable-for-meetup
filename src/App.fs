module App.View

open TodoListComponent
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.JS
open Fable.Helpers.React
open Fable.Helpers.React.Props

importAll "../sass/main.sass"

let todoList = com<TodoListComponent,_,_> createEmpty []
ReactDom.render(todoList,Browser.document.getElementById("elmish-app"));