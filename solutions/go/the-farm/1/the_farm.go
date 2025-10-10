package thefarm
import "errors"
import "fmt"

type InvalidCowsError struct{
    numOfCows int
    message string
}

func (e *InvalidCowsError) Error() string{
    return fmt.Sprintf("%v cows are invalid: %v", e.numOfCows, e. message)
}

func DivideFood(fc FodderCalculator, numOfCows int)(float64, error){
    totalFodder, err := fc.FodderAmount(numOfCows)

    if err != nil{
   		 return 0, err
    }
    
    factor, err := fc.FatteningFactor()
    
    if err != nil{
   		 return 0, err
    }
    
    return (totalFodder * factor) / float64(numOfCows), nil
}

func ValidateInputAndDivideFood(fc FodderCalculator, numOfCows int)(float64, error){
    if numOfCows > 0 {
        return DivideFood(fc, numOfCows)
    }

    return 0, errors.New("invalid number of cows")
}

func ValidateNumberOfCows(numOfCows int) error {
	if numOfCows < 0 {
        return &InvalidCowsError{
            numOfCows: numOfCows,
            message: "there are no negative cows",
        }
    }else if numOfCows == 0{
         return &InvalidCowsError{
            numOfCows: numOfCows,
            message: "no cows don't need food",
        }
    }else{
             return nil
        }
}

