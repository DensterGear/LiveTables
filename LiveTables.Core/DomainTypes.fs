module LiveTables.Core.DomainTypes

exception SourceError of string
exception SystemError of string
exception ValidationError of string

module TypesDefault =
    let int = Unchecked.defaultof<int>

module ServiceTypes =

    [<Struct>]
    type Score =
        { Home: int
          HomeName: string
          Away: int
          AwayName: string
          HomeScore: int
          AwayScore: int }

    [<Struct>]
    type LiveTableEntity =
        { Team: string
          Games: int
          Wins: int
          Draws: int
          Loose: int
          GoalScore: int
          GoalAgainst: int
          GoalDifference: int
          TotalPoints: int
          Form: string }
        static member Default =
            { Team = ""
              Games = TypesDefault.int
              Wins = TypesDefault.int
              Draws = TypesDefault.int
              Loose = TypesDefault.int
              GoalScore = TypesDefault.int
              GoalAgainst = TypesDefault.int
              GoalDifference = TypesDefault.int
              TotalPoints = TypesDefault.int
              Form = "" }

module Constants =
    
    module Game =
        
        [<Literal>]
        let WinShort = "W"
        
        [<Literal>]
        let DrawShort = "D"
        
        [<Literal>]
        let LooseShort = "L"
        
        [<Literal>]
        let WinPoints = 3
        
        [<Literal>]
        let DrawPoints = 1
        
        [<Literal>]
        let LoosePoints = 0
