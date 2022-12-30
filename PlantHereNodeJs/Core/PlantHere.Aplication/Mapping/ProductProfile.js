const Mapper = (value, classes) => {
    if(Array.isArray(value))
    {
        returnArray = []
        value.forEach(element => {
            returnArray.push(new classes(element.Name, element.Description, element.Discount, element.Price, element.UniqueId))
        });
    
        return returnArray;
    }

    else {
        return new classes(value.Name, value.Description, value.Discount, value.Price, value.UniqueId)
    }
   
}


module.exports = { Mapper }


