import { useState, useEffect } from "react";
import CardItem from "./CardItem";
import { CardData } from "../card-data";

interface Props {
    photo : string,
    name: string,
    field: string,
    description: string
}

const CardCollection: React.FC = () => {
  const [cards, setCards] = useState<CardData[]>([]);
  const [searchQuery, setSearchQuery] = useState<string>("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("/api/cards");
        const data = await response.json();
        setCards(data);
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);

  const filteredCards = cards.filter((card) =>
    card.name.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="container">
      <input
        type="text"
        placeholder="Search by name"
        className="border border-gray-400 rounded py-2 px-4 mb-4"
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
      />
      <div className="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 gap-4">
        {filteredCards.map((card) => (
          <CardItem key={card.id} data={card} />
        ))}
      </div>
    </div>
  );
};

const Cards = () => {
    return (
      <section className="grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-3">
        {CardData.map(({ photo, name, field, description }) => {
          return <CardItem photo = {photo} name={name} field={field} description={description} />;
        })}
      </section>
    );
  };


export default Cards;