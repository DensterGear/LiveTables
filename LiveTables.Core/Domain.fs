module LiveTables.Core.Domain

[<AutoOpen>]
module DomainHelpers =
    let (|HomeWin|AwayWin|Draw|) (homeScore: int, awayScore: int) =
        match (homeScore, awayScore) with
        | home, away when home > away -> HomeWin
        | home, away when home < away -> AwayWin
        | _ -> Draw
