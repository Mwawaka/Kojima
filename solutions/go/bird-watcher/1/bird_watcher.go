package birdwatcher

// TotalBirdCount return the total bird count by summing
// the individual day's counts.
func TotalBirdCount(birdsPerDay []int) int {
    var sum int
    
	for i:=0; i < len(birdsPerDay); i++ {
        sum += birdsPerDay[i]
    }

    return sum
}

func BirdsInWeek(birdsPerDay []int, week int) int {
    return TotalBirdCount(birdsPerDay[(week -1 ) * 7 : week * 7])
}


func FixBirdCountLog(birdsPerDay []int) []int {

    for i := 0; i < len(birdsPerDay); {
        birdsPerDay[i]++
       
        i += 2
    }

    return birdsPerDay
}
