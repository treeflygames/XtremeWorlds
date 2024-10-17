Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports Core

Module C_Database
    Friend Function GetFileContents(fullPath As String, Optional ByRef errInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader

        strContents = ""

        Try
            objReader = New StreamReader(fullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
        Catch ex As Exception
            errInfo = ex.Message
        End Try
        Return strContents
    End Function

#Region "Assets Check"
    Friend Sub CheckFiles(basePath As String, ByRef numAssets As Integer)
        Dim i As Integer = 1

        While File.Exists(Path.Combine(basePath, $"{i}{GfxExt}"))
            numAssets += 1
            i += 1
        End While
    End Sub
    
    Friend Sub CheckItems()
        CheckFiles(Path.Combine(Paths.Graphics, "Items"), NumItems)
    End Sub

    Friend Sub CheckCharacters()
        CheckFiles(Path.Combine(Paths.Graphics, "Characters"), NumCharacters)
    End Sub

    Friend Sub CheckPaperdolls()
        CheckFiles(Path.Combine(Paths.Graphics, "Paperdolls"), NumPaperdolls)
    End Sub

    Friend Sub CheckAnimations()
        CheckFiles(Path.Combine(Paths.Graphics, "Animations"), NumAnimations)
    End Sub

    Friend Sub CheckSkills()
        CheckFiles(Path.Combine(Paths.Graphics, "Skills"), NumSkills)
    End Sub

    Friend Sub CheckFog()
        CheckFiles(Path.Combine(Paths.Graphics, "Fogs"), NumFogs)
    End Sub

    Friend Sub CheckEmotes()
        CheckFiles(Path.Combine(Paths.Graphics, "Emotes"), NumEmotes)
    End Sub

    Friend Sub CheckPanoramas()
        CheckFiles(Path.Combine(Paths.Graphics, "Panoramas"), NumPanorama)
    End Sub

    Friend Sub CheckParallax()
        CheckFiles(Path.Combine(Paths.Graphics, "Parallax"), NumParallax)
    End Sub

    Friend Sub CheckPictures()
        CheckFiles(Path.Combine(Paths.Graphics, "Pictures"), NumPictures)
    End Sub

    Friend Sub CheckInterface()
        CheckFiles(Paths.Gui, NumInterface)
    End Sub

    Friend Sub CheckGradients()
        CheckFiles(Path.Combine(Paths.Gui, "gradients"), NumGradients)
    End Sub

    Friend Sub CheckDesigns()
        CheckFiles(Path.Combine(Paths.Gui, "designs"), NumDesigns)
    End Sub

    Friend Sub CacheMusic()
        ReDim MusicCache(Directory.GetFiles(Paths.Music, "*" & Types.Settings.MusicExt).Count)
        Dim files As String() = Directory.GetFiles(Paths.Music, "*" & Types.Settings.MusicExt)
        Dim maxNum As String = Directory.GetFiles(Paths.Music, "*" & Types.Settings.MusicExt).Count
        Dim counter As Integer = 0

        For Each FileName In files
            counter = counter + 1
            ReDim Preserve MusicCache(counter)

            MusicCache(counter) = System.IO.Path.GetFileName(FileName)
        Next

    End Sub

    Friend Sub CacheSound()
        ReDim SoundCache(Directory.GetFiles(Paths.Sounds, "*" & Types.Settings.SoundExt).Count)
        Dim files As String() = Directory.GetFiles(Paths.Sounds, "*" & Types.Settings.SoundExt)
        Dim maxNum As String = Directory.GetFiles(Paths.Sounds,  "*" & Types.Settings.SoundExt).Count
        Dim counter As Integer = 0

        For Each FileName In files
            counter = counter + 1
            ReDim Preserve SoundCache(counter)

            SoundCache(counter) = System.IO.Path.GetFileName(FileName)
        Next

    End Sub

#End Region

#Region "Blood"

    Sub ClearBlood()
       For i = 0 To Byte.MaxValue
            Blood(I).Timer = 0
        Next
    End Sub

#End Region

#Region "Npc"

    Sub ClearNpcs()
        Dim i As Integer

        ReDim NPC(MAX_NPCS)

       For i = 1 To MAX_NPCS
            ClearNpc(i)
        Next

    End Sub

    Sub ClearNpc(index As Integer)
        NPC(index) = Nothing
        ReDim NPC(index).Stat(StatType.Count - 1)
        ReDim NPC(index).DropChance(5)
        ReDim NPC(index).DropItem(5)    
        ReDim NPC(index).DropItemValue(5)
        ReDim NPC(index).Skill(6)
        NPC_Loaded(index) = False
    End Sub

    Sub StreamNpc(npcNum As Integer)
        If npcNum > 0 and NPC(npcNum).Name = "" Or NPC_Loaded(npcNum) = False Then
            NPC_Loaded(npcNum) = True
            SendRequestNpc(npcNum)
        End If
    End Sub

#End Region

#Region "Jobs"
    Sub ClearJobs()
        For i = 1 To MAX_JOBS
            ClearJob(i)
        Next
    End Sub

    Sub ClearJob(index As Integer)
        Job(index) = Nothing
        ReDim Job(index).Stat(StatType.Count - 1)
        Job(index).Name = ""
        Job(index).Desc = ""
        ReDim Job(index).StartItem(5)
        ReDim Job(index).StartValue(5)
        Job(index).MaleSprite = 1
        Job(index).FemaleSprite = 1
    End Sub
#End Region

#Region "Skills"

    Sub ClearSkills()
        Dim i As Integer

       For i = 1 To MAX_SKILLS
            ClearSkill(i)
        Next

    End Sub

    Sub ClearSkill(index As Integer)
        Skill(index) = Nothing
        Skill(index).Name = ""
        Skill_Loaded(index) = False
    End Sub

    Sub StreamSkill(skillNum As Integer)
        If skillNum > 0 And Skill(skillNum).Name = "" Or Skill_Loaded(skillNum) = False Then
            Skill_Loaded(skillNum) = True
            SendRequestSkill(skillNum)
        End If
    End Sub
#End Region
End Module