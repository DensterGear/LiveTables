module LiveTables.Core.Tests.ServicesTests

open LiveTables.Core
open DomainTypes.ServiceTypes
open LiveTables.Core.Services
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.``Calculate live table by all correct data`` () =
        let games = [
            { Home = 1
              HomeName = "Austria"
              Away = 2
              AwayName = "North Macedonia"
              HomeScore = 3
              AwayScore = 1 }
            { Home = 3
              HomeName = "Netherlands"
              Away = 4
              AwayName = "Ukraine"
              HomeScore = 3
              AwayScore = 2 }
            { Home = 4
              HomeName = "Ukraine"
              Away = 2
              AwayName = "North Macedonia"
              HomeScore = 2
              AwayScore = 1 }
            { Home = 3
              HomeName = "Netherlands"
              Away = 1
              AwayName = "Austria"
              HomeScore = 2
              AwayScore = 0 }
            { Home = 4
              HomeName = "Ukraine"
              Away = 1
              AwayName = "Austria"
              HomeScore = 0
              AwayScore = 1 }
            { Home = 2
              HomeName = "North Macedonia"
              Away = 3
              AwayName = "Netherlands"
              HomeScore = 0
              AwayScore = 3 }
        ]
        
        let liveTable = ScoresService.calculateLiveTable games

        Assert.AreEqual(liveTable.[0].Team, "Netherlands")
        Assert.AreEqual(liveTable.[1].Team, "Austria")
        Assert.AreEqual(liveTable.[2].Team, "Ukraine")
        Assert.AreEqual(liveTable.[3].Team, "North Macedonia")
        
        Assert.AreEqual(liveTable.[0].GoalDifference, 6)
        Assert.AreEqual(liveTable.[1].GoalDifference, 1)
        Assert.AreEqual(liveTable.[2].GoalDifference, -1)
        Assert.AreEqual(liveTable.[3].GoalDifference, -6)
        
        Assert.AreEqual(liveTable.[0].TotalPoints, 9)
        Assert.AreEqual(liveTable.[1].TotalPoints, 6)
        Assert.AreEqual(liveTable.[2].TotalPoints, 3)
        Assert.AreEqual(liveTable.[3].TotalPoints, 0)
