﻿namespace KindleChess

module Game =
    
    let AddTag (tagstr:string) (gm:Game) =
        let k,v = tagstr.Trim().Split([|'"'|])|>Array.map(fun s -> s.Trim())|>fun a -> a.[0],a.[1].Trim('"')
        match k with
        | "White" -> {gm with WhitePlayer = v}
        | "Black" -> {gm with BlackPlayer = v}
        | _ ->
            gm
    
    let SetaMoves(gm:Game) =
        let rec setamv (pmvl:MoveTextEntry list) mct prebd bd opmvl =
            if pmvl|>List.isEmpty then opmvl|>List.rev
            else
                let mte = pmvl.Head
                match mte with
                |HalfMoveEntry(mn,ic,mv,_) -> 
                    let amv = mv|>pMove.ToaMove bd mct
                    let nmte = HalfMoveEntry(mn,ic,mv,Some(amv))
                    let nmct = if bd.WhosTurn=Player.White then mct else mct+1
                    setamv pmvl.Tail nmct amv.PreBrd amv.PostBrd (nmte::opmvl)
                |RAVEntry(mtel) -> 
                    let nmct = if prebd.WhosTurn=Player.Black then mct-1 else mct
                    let nmtel = setamv mtel nmct prebd prebd []
                    let nmte = RAVEntry(nmtel)
                    setamv pmvl.Tail mct prebd bd (nmte::opmvl)
                |_ -> setamv pmvl.Tail mct prebd bd (mte::opmvl)
        
        let ibd = Board.Start
        let nmt = setamv gm.MoveText 1 ibd ibd []
        {gm with MoveText=nmt}


