module SearchComponent

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.JS
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable
open Fable.Import.Browser

[<Pojo>]
type SearchProps = { Add: string -> unit; Change: string -> unit }

[<Pojo>]
type SearchState = { text : string }

type SearchComponent(props) = 
    inherit React.Component<SearchProps,SearchState>(props)
    do base.setInitState({text = ""})

    member this.Change (evt : React.FormEvent) = 
        let value = string evt.target?value
        this.setState({text = value})
        this.props.Change(value)
    member this.Add evt = 
        this.props.Add(this.state.text)
        this.setState({text = ""})

    member this.render() = 
        div
            [ClassName "form-group"]
            [
                label [] [(str "Buscar o Agregar")]
                div 
                    [ ClassName "input-group mb-3"]
                    [
                        input [Type "text"; ClassName "form-control"; Placeholder "Buscar o Agregar"; Value this.state.text; OnChange this.Change;]
                        div 
                            [ ClassName "input-group-append"]
                            [
                                button [ClassName "btn btn-outline-secondary"; Type "button"; OnClick this.Add] [str "Agregar"]
                            ]
                    ]
            ]