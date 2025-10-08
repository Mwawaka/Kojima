package gross

func Units() map[string]int {
	return map[string]int{
        "quarter_of_a_dozen":	3,
		"half_of_a_dozen":	6,
		"dozen":	12,
		"small_gross":	120,
		"gross":	144,
		"great_gross":	1728,
    }
}

func NewBill() map[string]int {
	return make(map[string]int, 0)
}

func AddItem(bill, units map[string]int, item, unit string) bool {
	value, ok := units[unit]
    if !ok{
        return false
    }
	bill[item] += value
    return true
}

func RemoveItem(bill, units map[string]int, item, unit string) bool {
	value1, ok1 := bill[item]
	
    value2, ok2 := units[unit]
    
    quantity := value1 - value2
    
    if !ok1 || !ok2{
        return false
    }
  
	if quantity < 0 {
        return false
    }else if quantity == 0 {
        delete(bill, item)
       
        return true
    }else{
        bill[item] -= value2
       
        return true
    }
}

func GetItem(bill map[string]int, item string) (int, bool) {
	value, ok := bill[item]

    if !ok {
        return value, false
    }
    
	return value, true    
}
