import CardItem from "@/components/about/A2svSessionCardItem";
import cardsData from "../../data/about/about-card.json";

const Cards:React.FC = () => {
  return (
    <section className="grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-3 pl-12">
      {cardsData.map(({ logo, title, description }) => {
        return <CardItem key={title} title={title} logo={logo} description={description} />;
      })}
    </section>
  );
};

export default Cards;