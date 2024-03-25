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

    Friend Sub CheckCharacters()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "characters\" & i & GfxExt)
            NumCharacters = NumCharacters + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckPaperdolls()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "paperdolls\" & i & GfxExt)
            NumPaperdolls = NumPaperdolls + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckAnimations()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "animations\" & i & GfxExt)
            NumAnimations = NumAnimations + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckSkills()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Skills\" & i & GfxExt)
            NumSkills = NumSkills + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckFaces()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Faces\" & i & GfxExt)
            NumFaces = NumFaces + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckFog()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Fogs\" & i & GfxExt)
            NumFogs = NumFogs + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckEmotes()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Emotes\" & i & GfxExt)
            NumEmotes = NumEmotes + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckPanoramas()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Panoramas\" & i & GfxExt)
            NumPanorama = NumPanorama + 1
            i = i + 1
        End While
    End Sub

    Friend Sub CheckParallax()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Parallax\" & i & GfxExt)
            NumParallax = NumParallax + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckPictures()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Pictures\" & i & GfxExt)
            NumPictures = NumPictures + 1
            i = i + 1
        End While

    End Sub

    Friend Sub ChecKInterface()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Gui & i & GfxExt)
            NumInterface = NumInterface + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckGradients()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Gui & "gradients\" & i & GfxExt)
            NumGradients = NumGradients + 1
            i = i + 1
        End While

    End Sub

    Friend Sub CheckDesigns()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Gui & "designs\" & i & GfxExt)
            NumDesigns = NumDesigns + 1
            i = i + 1
        End While

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
            Application.DoEvents()
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
            Application.DoEvents()
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

#Region "Npc's"

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