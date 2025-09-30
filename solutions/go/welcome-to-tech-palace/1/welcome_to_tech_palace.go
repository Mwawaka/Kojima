package techpalace
import "strings"
import "fmt"

// WelcomeMessage returns a welcome message for the customer.
func WelcomeMessage(customer string) string {
	return "Welcome to the Tech Palace, " + strings.ToUpper(customer)
}

// AddBorder adds a border to a welcome message.
func AddBorder(welcomeMsg string, numStarsPerLine int) string {
    str := strings.Repeat("*",numStarsPerLine)
	return fmt.Sprintf("%s\n%s\n%s", str, welcomeMsg, str)
}

// CleanupMessage cleans up an old marketing message.
func CleanupMessage(oldMsg string) string {
    
	return strings.TrimSpace(strings.ReplaceAll(oldMsg,"*",""))
}
