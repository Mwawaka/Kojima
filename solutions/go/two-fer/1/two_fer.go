package twofer
import "fmt"

// ShareWith returns a string with a description of who you'll share cookie with.
func ShareWith(name string) string {
	if name == ""{
       return fmt.Sprintf("One for you, one for me.") 
    }
    
	return fmt.Sprintf("One for %v, one for me.", name)
}
