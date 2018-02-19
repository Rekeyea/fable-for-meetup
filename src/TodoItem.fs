module TodoItemComponent

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.JS
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.React

type [<Pojo>] TodoItemProps = 
    {   key: string;
        text: string }

 type [<Pojo>] TodoItemState = 
    {   isChecked : bool }

type TodoItemComponent(props) = 
    inherit React.Component<TodoItemProps,TodoItemState>(props)
    do base.setInitState({ isChecked = false })

    member this.toggle evt =
        this.setState({ isChecked = not this.state.isChecked })

    member this.render() = 
        let className = if this.state.isChecked then "list-group-item active" else "list-group-item"
        li 
            [ 
                ClassName className 
                OnClick this.toggle
            ]
            [
                str this.props.text
            ]

