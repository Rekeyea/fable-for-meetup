module TodoListComponent

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.JS
open Fable.Helpers.React
open Fable.Helpers.React.Props
open TodoItemComponent
open SearchComponent
open Fable

[<Pojo>]
type TodoItem = { text : string }

[<Pojo>]
type TodoListState = 
    { items :  TodoItem list }

let todoItems = [
    {text = "First Item"};
    {text = "Second Item"};
    {text = "Third Item"};
    {text = "Fourth Item"};
]

type TodoListComponent(props) = 
    inherit React.Component<obj,TodoListState>(props)
    do base.setInitState({ items = todoItems })

    member this.SearchTextChanged text = ()

    member this.AddItem text = 
        let items = this.state.items
        let newItem = {text = text}
        this.setState({items = [newItem] |> List.append items})

    member this.render() = 
        let items = 
            this.state.items 
            |> List.map(fun item -> com<TodoItemComponent,_,_> { 
                text = item.text; 
                key = System.Guid.NewGuid().ToString()} [])
            |> Seq.ofList

        let search = com<SearchComponent,_,_> { Change = this.SearchTextChanged; Add = this.AddItem } []
        div
            [ ClassName "container"; Id "todoList" ]
            [
                div
                    [ ClassName "row" ]
                    [
                        form
                            [ClassName "col-12"]
                            [
                                search
                                ul 
                                    [ ClassName "list-group"]
                                    [
                                        yield! items
                                    ]
                            ]
                    ]
            ]
    