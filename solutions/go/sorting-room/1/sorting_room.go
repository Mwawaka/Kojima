package sorting
import "strconv"
import "fmt"

func DescribeNumber(f float64) string {
	return fmt.Sprintf("This is the number %.1f", f)
}

type NumberBox interface {
	Number() int
}

func DescribeNumberBox(nb NumberBox) string {
	return fmt.Sprintf("This is a box containing the number %d.0", nb.Number())
}

type FancyNumber struct {
	n string
}

func (i FancyNumber) Value() string {
	return i.n
}

type FancyNumberBox interface {
	Value() string
}

func ExtractFancyNumber(fnb FancyNumberBox) int {
	str, ok := fnb.(FancyNumber)
    
    if ok{
        n, err := strconv.Atoi(str.Value())
        
        if err !=nil{
            fmt.Println(err)
        }
        
        return n
    }
    
    return 0
}

func DescribeFancyNumberBox(fnb FancyNumberBox) string {
	fancyNumber := ExtractFancyNumber(fnb)

    if fancyNumber == 0{
        return fmt.Sprintf("This is a fancy box containing the number 0.0")
    }

    return fmt.Sprintf("This is a fancy box containing the number %d.0", fancyNumber)
}

func DescribeAnything(i interface{}) string {

    switch v := i.(type){
        case int:
        	return DescribeNumber(float64(v))
        case float64:
        	return DescribeNumber(v)
        case NumberBox:
        	return DescribeNumberBox(v)
        case FancyNumberBox:
        	return DescribeFancyNumberBox(v)
    }
	
    return "Return to sender"
}
