import React from "react";
import { JokeStructure } from "../../features/api/JokesApi";

interface JokeProp {
  joke: JokeStructure;
}
function JokeCard({ joke }: JokeProp) {
  return (
    <div className="max-w-md mx-auto mt-4 bg-white shadow-md rounded-lg overflow-hidden">
      <div className="px-4 py-2">
        <p className="text-xl font-bold text-gray-800">{joke.joke}</p>
        <p className="text-sm text-gray-500">{joke.category}</p>
      </div>
    </div>
  );
}




export default JokeCard;


