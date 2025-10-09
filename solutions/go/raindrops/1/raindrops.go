package raindrops
import "strconv"

func Convert(number int) string {
 if number % 105 == 0 {
        return "PlingPlangPlong"
    }    else if number % 35 == 0 {
        return "PlangPlong"
    }else if number % 21 == 0 {
        return "PlingPlong"
    }else if number % 15 == 0 {
        return "PlingPlang"
    }else if number % 7 == 0 {
        return "Plong"
    }else if number % 5 == 0 {
        return "Plang"
    }else if number % 3 == 0 {
        return "Pling"
    }else{
        return strconv.Itoa(number)
    }
}
