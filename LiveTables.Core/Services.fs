module LiveTables.Core.Services

open Domain
open DomainTypes.ServiceTypes
open LiveTables.Core.DomainTypes

module ScoresService =
    let sumTeamStatistic (x: LiveTableEntity) (y: LiveTableEntity) =
        { Team = x.Team
          Games = x.Games + y.Games
          Wins = x.Wins + y.Wins
          Draws = x.Draws + y.Draws
          Loose = x.Loose + y.Loose
          GoalScore = x.GoalScore + y.GoalScore
          GoalAgainst = x.GoalAgainst + y.GoalAgainst
          GoalDifference = x.GoalDifference + y.GoalDifference
          TotalPoints = x.TotalPoints + y.TotalPoints
          Form = x.Form + y.Form }
    
    [<CompiledName("CalculateLiveTable")>]
    let calculateLiveTable (scores: Score list) : LiveTableEntity list =
        scores
        |> List.map
            (fun game ->
                let homeDefault =
                    { LiveTableEntity.Default with
                          Team = game.HomeName
                          GoalScore = game.HomeScore
                          GoalAgainst = game.AwayScore
                          GoalDifference = game.HomeScore - game.AwayScore }

                let awayDefault =
                    { LiveTableEntity.Default with
                          Team = game.AwayName
                          GoalScore = game.AwayScore
                          GoalAgainst = game.HomeScore
                          GoalDifference = game.AwayScore - game.HomeScore }

                match (game.HomeScore, game.AwayScore) with
                | HomeWin ->
                    [ { homeDefault with
                            Wins = 1
                            TotalPoints = Constants.Game.WinPoints
                            Form = Constants.Game.WinShort}
                      { awayDefault with
                            Loose = 1
                            TotalPoints = Constants.Game.LoosePoints
                            Form = Constants.Game.LooseShort} ]
                | AwayWin ->
                    [ { homeDefault with
                            Loose = 1
                            TotalPoints = Constants.Game.LoosePoints
                            Form = Constants.Game.LooseShort}
                      { awayDefault with
                            Wins = 1
                            TotalPoints = Constants.Game.WinPoints
                            Form = Constants.Game.WinShort} ]
                | _
                | Draw ->
                    [ { homeDefault with
                            Draws = 1
                            TotalPoints = Constants.Game.DrawPoints
                            Form = Constants.Game.DrawShort}
                      { awayDefault with
                            Draws = 1
                            TotalPoints = Constants.Game.DrawPoints
                            Form = Constants.Game.DrawShort} ])
        |> List.collect id
        |> List.groupBy (fun game -> game.Team)
        |> List.map (fun (_, games) ->
            games
            |> List.reduce sumTeamStatistic)
        |> List.sortByDescending(fun score -> score.TotalPoints, score.GoalDifference)
