// Package weather provides tools for predicting weather conditions in Goblinocus.
package weather

// CurrentCondition represents the current weather condition in Goblinocus.
var CurrentCondition string
// CurrentLocation represents the current location in Goblinocus.
var CurrentLocation string

// Forecast returns a string value specifying the location in Goblinocus and its current weather condition.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
