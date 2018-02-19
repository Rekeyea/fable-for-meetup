module App.Types

open Global

type AppState = {
  counter : int
}

//@todo: delete ********************** 
type Msg =
  | CounterMsg of Counter.Types.Msg
  | HomeMsg of Home.Types.Msg

type Model = {
    currentPage: Page
    counter: Counter.Types.Model
    home: Home.Types.Model
  }
// ************************************