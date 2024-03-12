import { useState, useEffect } from 'react';
import { MarriottFood } from '../types/MarriottFood';

function FoodList() {
  //Left Side: we have the state object and the state setter
  //Right Side: Create an MarriottFood array of objects that defines the type of the useState (Marriott food is passed in as an array that is initially blank)
  const [foodData, setFoodData] = useState<MarriottFood[]>([]);

  //If it does not need to get the data (because nothing has changed, then we wont constantly be getting the data)
  useEffect(() => {
    //Set up thigs that are going to happen and then call the fatch food data to bring it in.
    const fetchFoodData = async () => {
      const rsp = await fetch('http://localhost:5163/marriottfood');
      const f = await rsp.json();
      setFoodData(f);
    };
    fetchFoodData();
    //If we do not find anything, just pass in an empty array
  }, []);

  return (
    <>
      <div className="row">
        <h4 className="text-center">This is the best Marriott Food</h4>
      </div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Event Name</th>
            <th>Vendor Name</th>
            <th>Food Rating</th>
          </tr>
        </thead>
        <tbody>
          {/* Get our food data and map it. Our initial variable is f that keeps track of which piece of data we are on */}
          {foodData.map((f) => (
            <tr key={f.foodId}>
              <td>{f.eventName}</td>
              <td>{f.vendorName}</td>
              <td>{f.foodRating}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default FoodList;
