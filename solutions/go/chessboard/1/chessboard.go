package chessboard

type File []bool

type Chessboard map[string]File

func CountInFile(cb Chessboard, file string) int {
    squareFile := cb[file]
	
    count := 0

    for _, v := range squareFile{
        if v{
            count++
        }
    }
    return count
}

func CountInRank(cb Chessboard, rank int) int {
	if rank < 1 || rank > 8{
        return 0
    }

    count := 0
	i := rank - 1
    
    for _, file := range cb {
    if i < len(file) && file[i]{
        count ++
    }    
    }

    return count    
}

func CountAll(cb Chessboard) int {
	return 8 * 8
}

func CountOccupied(cb Chessboard) int {
	count := 0
   
    for i := 1; i < 9; i++ {
        count += CountInRank(cb, i)
    }
   
    return count
}
