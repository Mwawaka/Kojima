package lasagna

func PreparationTime(layers []string, minutes int) int{
    numOfLayers := len(layers)
    if minutes == 0 {
        return numOfLayers * 2
    }
    return numOfLayers *  minutes
}

func Quantities(layers []string) (int, float64){
    noodles := Count(layers, "noodles")

    sauce := Count(layers, "sauce")

    return noodles * 50, float64(sauce) * 0.2 
}

func AddSecretIngredient(ingredient1, ingredient2 []string) {
    item := ingredient1[len(ingredient1) - 1]
    ingredient2[len(ingredient2) - 1] = item
}

func ScaleRecipe(quantities []float64, portions int) []float64{
	var newQuantity float64
    
    newPortions :=  float64(portions) / 2
    
    newQuantities := make([]float64, 0)
    
    for _, quantity := range quantities{
      newQuantity =  quantity * newPortions
     
      newQuantities = append(newQuantities, newQuantity)
    }
  
    return newQuantities
}

func Count (slice []string, word string) int{
	count := 0
    
    for _, item := range slice {
       
        if item == word {
            count++
        }
    }

    return count  
}
